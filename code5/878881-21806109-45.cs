    // https://stackoverflow.com/q/21800450/1768303
    
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Console_21800450
    {
        public class Program
        {
            static async Task DoSomethingAsync(int id)
            {
                await Task.Delay(50);
                UpdateMaxThreads();
                Console.WriteLine(@"DidSomethingAsync({0})", id);
            }
    
            static async Task DoSomethingAsync2(int id)
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(50);
                    UpdateMaxThreads();
                    Console.WriteLine(@"DidSomethingAsync2({0})", id);
                });
            }
    
            static async Task MainAsync(Func<int, Task> tester)
            {
                List<Task> tasks = new List<Task>();
                for (int i = 1; i <= 1000; i++)
                    tasks.Add(tester(i)); // Can replace with any version
                await Task.WhenAll(tasks);
            }
    
            volatile static int s_maxThreads = 0;
    
            static void UpdateMaxThreads()
            {
                var threads = Process.GetCurrentProcess().Threads.Count;
                // not using locks for simplicity
                if (s_maxThreads < threads)
                    s_maxThreads = threads;
            }
    
            static void TestAsync(Func<int, Task> tester)
            {
                s_maxThreads = 0;
                var stopwatch = new Stopwatch();
                stopwatch.Start();
    
                MainAsync(tester).Wait();
    
                Console.WriteLine(
                    "time, ms: " + stopwatch.ElapsedMilliseconds +
                    ", threads at peak: " + s_maxThreads);
            }
    
            static void Main()
            {
                Console.WriteLine("Press enter to test with Task.Delay ...");
                Console.ReadLine();
                TestAsync(DoSomethingAsync);
                Console.ReadLine();
    
                Console.WriteLine("Press enter to test with Thread.Sleep ...");
                Console.ReadLine();
                TestAsync(DoSomethingAsync2);
                Console.ReadLine();
            }
    
        }
    }
