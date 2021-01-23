    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    namespace Thread_class
    {
       class Program
       {
       
        static void Main(string[] args)
        {
            SubThread subthread = new SubThread();
            Thread thread = new Thread(subthread.PrintValue);
            thread.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Inside Main Class " + i);
                Thread.Sleep(1);
            }
            thread.Join();
            Console.ReadKey();
        }
    }
    class SubThread
    {
        public void PrintValue()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Inside PrintValue() of SubThread Class " + i);
                Thread.Sleep(1);
               }
           }
       }
    }
