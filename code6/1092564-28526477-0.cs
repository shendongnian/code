    using System;
    using System.Threading;
    
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadMethod));    
    
                Console.ReadKey();
            }
    
            static void ThreadMethod (object state){ 
                Console.WriteLine("Hello");
            }
    
        }
    }
