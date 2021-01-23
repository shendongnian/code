    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static object lock1 = new object();
            private static ReaderWriterLockSlim lock2 = new ReaderWriterLockSlim();
    
            public static int DoLock1(int value)
            {
                lock (lock1)
                    return value;
            }
    
            public static int DoLock2(int value)
            {
                lock2.EnterWriteLock();
                try
                {
                    return value;
                }
                finally
                {
                    lock2.ExitWriteLock();
                }
    
            }
    
    
            static void Main(string[] args)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < 10000000; i++)
                {
                    DoLock1(i);
                }
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
    
                sw.Reset();
                sw.Start();
                for (int i = 0; i < 10000000; i++)
                {
                    DoLock2(i);
    
                }
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                Console.ReadLine();
            }
        }
    }
