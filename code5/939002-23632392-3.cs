    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    class ThreadLocalDemo
    {
                static void Main()
            {
                ThreadLocal<string> ThreadName = new ThreadLocal<string>(() =>
                {
                    return "Thread" + Thread.CurrentThread.ManagedThreadId;
                });
    
                Action action = () =>
                {
                    bool repeat = ThreadName.IsValueCreated;
    
                    Console.WriteLine("ThreadName = {0} {1}", ThreadName.Value, repeat ? "(repeat)" : "");
                };
                Parallel.Invoke(action, action, action, action, action, action, action, action);
    
                ThreadName.Dispose();
            }
    }
