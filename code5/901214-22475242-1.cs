    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    
        namespace ConsoleApplication_22465346
        {
            public class Program
            {
                [ThreadStatic]
                static volatile int s_mark;
        
                // Main
                public static void Main(string[] args)
                {
                    const int THREADS = 50;
        
                    // init the thread pool
                    ThreadPool.SetMaxThreads(
                        workerThreads: THREADS, completionPortThreads: THREADS);
                    ThreadPool.SetMinThreads(
                        workerThreads: THREADS, completionPortThreads: THREADS);
        
                    // populate s_max for non-IOCP threads
                    for (int i = 0; i < THREADS; i++)
                    {
                        ThreadPool.QueueUserWorkItem(_ =>
                        { 
                            s_mark = -1;
                            Thread.Sleep(1000);
                        });
                    }
                    Thread.Sleep(2000);
        
                    // non-IOCP test
                    Task.Run(() =>
                    {
                        // by now all non-IOCP threads have s_mark == -1
                        Console.WriteLine("Task.Run, s_mark: " + s_mark);
                        Console.WriteLine("IsThreadPoolThread: " + Thread.CurrentThread.IsThreadPoolThread);
                    }).Wait();
        
                    // IOCP test
                    var httpClient = new HttpClient();
                    httpClient.GetStringAsync("http://example.com").ContinueWith(t =>
                    {
                        // all IOCP threads have s_mark == 0
                        Console.WriteLine("GetStringAsync.ContinueWith, s_mark: " + s_mark);
                        Console.WriteLine("IsThreadPoolThread: " + Thread.CurrentThread.IsThreadPoolThread);
                    }, TaskContinuationOptions.ExecuteSynchronously).Wait();
        
                    Console.WriteLine("Enter to exit...");
                    Console.ReadLine();
                }
            }
        }
    }
