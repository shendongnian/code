    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Test
        {
            private static Test instance;
            public static Test Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Test();
                    }
                    return instance;
                }
            }
    
            private static Semaphore _pool = new Semaphore(0, 10);
            private Test()
            {
                _pool.Release(10);
            }
    
            public async void AddTask(int count)
            {   
                _pool.WaitOne();
                var task = Task.Delay(TimeSpan.FromSeconds(3));
                Console.WriteLine("{0}, {1}", count, DateTime.Now);
                await task;
                _pool.Release();
            }
        }
    }
