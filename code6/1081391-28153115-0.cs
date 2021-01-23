    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Diagnostics;
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                int maxtimeout = 100; // max timeout is 100 seconds, when it reaches this break
                var prevtime = ((DateTime.Now - DateTime.MinValue).TotalMilliseconds) / 1000;
                Console.WriteLine("current time = {0} seconds", prevtime);
                for (; ; )
                {
                    Thread.Sleep(5000);
                    var newtime = ((DateTime.Now - DateTime.MinValue).TotalMilliseconds) / 1000;
                    var timeelapsed = newtime - prevtime;
                    Console.WriteLine("Time elapsed = {0}", timeelapsed);
                    if (timeelapsed >= maxtimeout)
                    {
                        Console.WriteLine("Max timeout reached");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Max timeout no reached elapased time = {0}", timeelapsed);
                    }
                }
            }
        }
    }
