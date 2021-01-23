    using System;
    using System.Threading;
    
    namespace ConsoleApp1
    {
        class Program
        {
            private static volatile int val1 = 0;
            static Object Locker = new Object();
    
            public static void Func1()
            {
                try
                {
                }
                finally
                {
                    Thread.Sleep(5000);
                }
                //Func2();
    
                while (true)
                {
                    //Lock the access to the member
                    lock (Locker)
                        val1++;
                }
            }
    
            public static void Main()
            {
                var thread = new Thread(Func1);
                thread.Start();
    
                Thread.Sleep(1000);
                //Not needed. Just to make sure
                lock (Locker)
                {
                    thread.Abort();
                    thread.Join();
                }
    
                Console.WriteLine(val1);  // val1 is non-zero!
                                          // Now it is zero
                Console.ReadLine();
            }
        }
    }
