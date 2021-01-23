    using System;
    using System.Diagnostics;
    using System.Threading;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int TimeToWait = 15;
                var sw = Stopwatch.StartNew();
                var mnu = new ManualResetEvent(false);
                while (sw.Elapsed.Seconds <= TimeToWait)
                {
                    Console.WriteLine(sw.ElapsedMilliseconds);
                    mnu.WaitOne(100);
                }
                Console.ReadKey();
            }
        }
    }
