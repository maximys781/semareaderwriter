using System;
using System.Threading;

namespace paraproglab1
{
    class Program
    {
     static void Main(string[] args)
        {
           
           for (int i = 1; i < 4; i++){
               Readerwriter reader = new Readerwriter(i);
           }
           Console.ReadLine();
            for(int j = 1; j < 3; j++){
                Readerwriter writer = new Readerwriter(j);
           }
            Console.WriteLine();

        }
        
    }
    class Readerwriter
    {
        static Semaphore sem = new Semaphore(1, 1);//создаем семафор 1-ый параметр отвечает какому числу объектов будет доступен семафор, а 2-ой какое максимальное число объектов может его использовать
        
        Thread myThread;
        Thread myThread1;
        
        public Readerwriter(int nrsem = 3, int nwsem=2)
        {
            Thread myThread  = new Thread(new ParameterizedThreadStart(Read));
            myThread.Name = "Читатель " + nrsem.ToString();
            myThread.Start(nrsem);

            Thread myThread1  = new Thread(new ParameterizedThreadStart(Write));
            myThread1.Name = "Писатель " + nwsem.ToString();
            myThread1.Start(nwsem);
        }
static void Read(object num){
  int iteration=0;
  int NI=15;  
while(iteration<NI){
    sem.WaitOne();
    Console.WriteLine("{0} читает", Thread.CurrentThread.Name);
               Console.WriteLine("Писатель ждет"); 
               Thread.Sleep(200);
                iteration++;
                sem.Release(1);
                
 }
 }
   static void Write(object num){
      int iteration=0;
  int NI=15;  
while(iteration<NI){
    sem.WaitOne();
    Console.WriteLine("{0} пишет", Thread.CurrentThread.Name);
                   Console.WriteLine("Читатель ждет"); 
                Thread.Sleep(500);
                iteration++;
                sem.Release(1);             
 }
 Console.WriteLine("Итерация окончена");
 return;
 }
}
}
       /*  public Readerwriter(int j=0)
        {
            myThread = new Thread(Write);
            myThread.Name = "Писатель " + j.ToString();
            myThread.Start();
        }*/
      
    
            
        

