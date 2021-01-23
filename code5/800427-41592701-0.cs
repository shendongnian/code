            using System;
            using System.Threading;
            using System.Threading.Tasks;
            namespace TaskTest2
            {
    
                class Program
                {
                    static ManualResetEvent mre = new ManualResetEvent(false);
                    static void Main(string[] args)
                    {
                       mre.Set();
                       Task.Factory.StartNew(() =>
                        {
                            while (true)
                            {
                                Console.WriteLine("________________");
                                mre.WaitOne();
                            }
                        } );
                        Thread.Sleep(10000);
                        mre.Reset();
                        Console.WriteLine("Task Paused");
                        Thread.Sleep(10000);
                        Console.WriteLine("Task Will Resume After 1 Second");
                        Thread.Sleep(1000);
                        mre.Set();
                        Thread.Sleep(10000);
                        mre.Reset();
                        Console.WriteLine("Task Paused");
         
                        Console.Read();
                    }
                }
            }
