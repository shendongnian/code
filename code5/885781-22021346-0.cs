    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ParallelTest
    {
        class Program
        {
            static AutoResetEvent autoReset = new AutoResetEvent(false);
    
            static void Main(string[] args)
            {
                // since this is an async method it will be run in a different thread
                DoSomething();
    
                // wait for the async method to signal the main thread
                autoReset.WaitOne();
    
                Console.WriteLine("done");
    
            }
    
            async static void DoSomething()
            {
                // create some common data
                const int count = 50000;
                const int factor = 3;
    
    
                // create some tasks
                var task1 = Task.Run(() =>
                {
                    int x = 0;
                    for (int i = 0; i < count * 2; ++i)
                    {
                        x += i + factor * 3;
                        Console.WriteLine("task1: " + i + factor * 3);
                    }
                    return x;
                });
    
                var task2 = Task.Run(() =>
                {
                    int x = 0;
                    for (int i = 0; i < count * 2; ++i)
                    {
                        x += i + factor * 4;
                        Console.WriteLine("task2: " + i + factor * 4);
                    }
                    return x;
                });
    
                var task3 = Task.Run(() =>
                {
                    int x = 0;
                    for (int i = 0; i < count * 2; ++i)
                    {
                        x += i + factor * 5;
                        Console.WriteLine("task3: " + i + factor * 5);
                    }
                    return x;
                });
    
    
                // create a resulttask which will run all the tasks in parallel
                var resultTask = Task.WhenAll(task1, task2, task3);
    
                // start the task and wait till it finishes
                var results = await resultTask;
    
                // display the results
                for (int i = 0; i < results.Length; ++i)
                {
                    Console.WriteLine("result" + i + ": " + results[i]);
                }
    
                // signal main thread
                autoReset.Set();
            }
        }
    }
