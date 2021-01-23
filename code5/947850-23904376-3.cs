    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    namespace ConsoleApplication3 {
        class Class1 {
            public int Value = 0;
        }
        class Test {
            private static readonly object m_lock = new object();
            static void Main() {
                Class1 r1 = new Class1();
                r1.Value = 2;
                Class1 r2 = new Class1();
                r2.Value = 2;
                Console.WriteLine("MainThread Original Value: {0} ", r1.Value);
                ThreadStart starter = delegate { test(r1, r2); };
                Thread subThread = new Thread(starter);
                subThread.Start();
                Thread.Sleep(1000);
                r1.Value = 1234;
                Console.WriteLine("MainThread New Value: {0} ", r1.Value);
                Thread.Sleep(1000);
                r1.Value = 4321;
                Console.WriteLine("MainThread New Value: {0} ", r1.Value);
                Thread.Sleep(1000);
                r1.Value = 5678;
                Console.WriteLine("MainThread New Value: {0} ", r1.Value);
            }
            static void test(Class1 r, Class1 tr) {
                lock (m_lock) {
                    Class1 local = tr;
                    Console.WriteLine("SubThread Original Values: {0}, {1}", local.Value, r.Value);
                    Thread.Sleep(500);
                    Console.WriteLine("Working... local value: {0}", local.Value);
                    Thread.Sleep(500);
                    Console.WriteLine("Working... local value: {0}", local.Value);
                    Thread.Sleep(500);
                    Console.WriteLine("Working... local value: {0}", local.Value);
                    Thread.Sleep(500);
                    Console.WriteLine("Working... local value: {0}", local.Value);
                    Thread.Sleep(500);
                    Console.WriteLine("Working... local value: {0}", local.Value);
                    Thread.Sleep(500);
                    Console.WriteLine("Working... local value: {0}", local.Value);
                    Thread.Sleep(500);
                    Console.WriteLine("Working... local value: {0}", local.Value);
                    Thread.Sleep(500);
                    Console.WriteLine("SubThread Final Values: {0}, {1}", local.Value, r.Value);
                    Console.ReadLine();
                }
            }
        }
    }
