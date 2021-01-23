    using System;
    using System.Threading;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static void Main()
            {
                Timer t = new Timer(TimerCallback, null, 0, 2000);
                // Wait for the user to hit <Enter>
                Console.ReadLine();
            }
            private static void TimerCallback(Object o)
            {
                Console.WriteLine("In TimerCallback: " + DateTime.Now);
                DateTime s = DateTime.Now;
                TimeSpan ts = new TimeSpan(23, 27, 0);
                s = s.Date + ts;
                if (DateTime.Now > s && !fired) 
                { 
                    Console.WriteLine("Do the Job");
                    fired = true;
                }
                else if (DateTime.Now < s)
                {
                    fired = false;
                }
            }
            private static bool fired = false;
        }
    }
