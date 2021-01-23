    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ThreadTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                Thread t1 = new Thread(Method1);
                Thread t2 = new Thread(Method2);
                t1.Start();
                Thread.Sleep(100);
                t2.Start();
                t1.Join();
                t2.Join();
                _autoEvent1.Close();
                _autoEvent2.Close();
            }
     
            private static void Method1()
            {
    
                do
                {
                   _autoEvent2.WaitOne();
                    
                    if (!SharedCode(Thread.CurrentThread.ManagedThreadId))
                    {
                        break;
                    }
                       
                    _autoEvent1.Set();
                } while (true);
            }
    
            private static void Method2()
            {
                do
                {
                    _autoEvent1.WaitOne();
                    //_autoEvent2.Set();
                    if (!SharedCode(Thread.CurrentThread.ManagedThreadId))
                        break;
                    _autoEvent2.Set();
                } while (true);
            }
    
            private static bool SharedCode(int threadId)
            {
               lock (_lockObject)
                {
                  
                    Interlocked.Increment(ref _count);
                    if (_count > 10)
                        return false;
                    Console.WriteLine("ThreadId={0} , count={1}", threadId,_count);
                }
    
                return true;
            }
            private  static AutoResetEvent _autoEvent1 = new AutoResetEvent(true);
            private static AutoResetEvent _autoEvent2 = new AutoResetEvent(true);
            private static Object _lockObject = new object();
            private static int _count = 0;
        }
    }
