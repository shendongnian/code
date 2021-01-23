    using System;
    using System.Threading;
     
    class Program
    {
        static ManualResetEvent mre = new ManualResetEvent(false);
     
        static void example(int a, int b)
        {
            int d = a;
            int w, c;
            ThreadPool.GetMinThreads(out w, out c);
            ThreadPool.SetMinThreads(100, c);
            ThreadPool.QueueUserWorkItem(new WaitCallback(method), d);
        }
     
        static void method(object d)
        {
            mre.WaitOne();
            Console.WriteLine(d);
        }
     
        static void Main(string[] args)
        {
            example(1, 2);
            example(3, 4);
            Thread.Sleep(1000);
            Console.WriteLine("The threads are still waiting after 1 sec...");
            mre.Set();
            Thread.Sleep(1000);
            Console.WriteLine("Now I hope they finished");
        }
    }
