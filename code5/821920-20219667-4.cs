    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    namespace Threads
    {
        class Storage
        {
            static int _number;
            public readonly static object LockNumber = new object();
            public static int Number
            {
                get
                {
                    lock (LockNumber)
                    {
                        Monitor.Pulse(LockNumber);
                        return _number;
                    }
                }
                set
                {
                    lock (LockNumber)
                    {
                        _number = value;
                        Monitor.Pulse(LockNumber);
                        Monitor.Wait(LockNumber);
                    }
                }
            }
        }
        class Counter
        {
            public Thread t = new Thread(new ThreadStart(CounterFunction));
            public Counter()
            {
                t.Start();
            }
            public static void CounterFunction()
            {
                for (int i = 0; i < 25; i++)
                {
                    Storage.Number = i;
                }
                Storage.Number = -1;
            }
        }
        class Printer
        {
            public Thread t1 = new Thread(new ThreadStart(Print));
            public Printer()
            {
                t1.Start();
            }
            public static void Print()
            {
                Boolean stop = false;
                while (!stop)
                {
                    if (Storage.Number != -1)
                    {
                        Console.WriteLine("Number is " + Storage.Number);
                    }
                    else
                    {
                        stop = true;
                    }
                }
            }
        }
        class Check
        {
            static void Main()
            {
                Storage s1 = new Storage();
                Counter c = new Counter();
                Printer p = new Printer();
                c.t.Join();
                if (!c.t.IsAlive)
                {
                    p.t1.Abort();
                }
                Thread.Sleep(10000);
            }
        }
    }
