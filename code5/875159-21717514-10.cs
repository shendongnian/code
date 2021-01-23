    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using System.Net;
    
    namespace Console_21690385
    {
        class Program
        {
            const int MAX_REQS = 200;
    
            // implement GetStringAsync
            static async Task<string> GetStringAsync(string url)
            {
                using (var response = await WebRequest.Create(url).GetResponseAsync())
                using (var stream = response.GetResponseStream())
                using (var reader = new System.IO.StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
    
            // test using GetStringAsync
            static async Task TestWithGetStringAsync()
            {
                var tasks = Enumerable.Range(1, MAX_REQS).Select((i) =>
                    GetStringAsync("http://www.bing.com/search?q=item1=" + i));
    
                Console.WriteLine("Threads before completion: " + Process.GetCurrentProcess().Threads.Count);
    
                await Task.WhenAll(tasks);
    
                Console.WriteLine("Threads after completion: " + Process.GetCurrentProcess().Threads.Count);
            }
    
            // implement GetStringSync
            static string GetStringSync(string url)
            {
                using (var response = WebRequest.Create(url).GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new System.IO.StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
    
            // test using GetStringSync
            static async Task TestWithGetStringSync()
            {
                var tasks = Enumerable.Range(1, MAX_REQS).Select((i) =>
                    Task.Factory.StartNew(
                        () => GetStringSync("http://www.bing.com/search?q=item1=" + i),
                        CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default));
    
                Console.WriteLine("Threads before completion: " + Process.GetCurrentProcess().Threads.Count);
    
                await Task.WhenAll(tasks);
    
                Console.WriteLine("Threads after completion: " + Process.GetCurrentProcess().Threads.Count);
            }
    
            // run either of the tests
            static void RunTest(Func<Task> runTest)
            {
                Console.WriteLine("Threads at start: " + Process.GetCurrentProcess().Threads.Count);
    
                var stopWatch = new Stopwatch();
                stopWatch.Start();
    
                var testTask = runTest();
    
                while (!testTask.IsCompleted)
                {
                    Console.WriteLine("Currently threads: " + Process.GetCurrentProcess().Threads.Count);
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Threads at end: " + Process.GetCurrentProcess().Threads.Count + ", time: " + stopWatch.Elapsed);
    
                testTask.Wait();
            }
    
            static void Main(string[] args)
            {
                ThreadPool.SetMaxThreads(MAX_REQS * 2, MAX_REQS * 2);
                ThreadPool.SetMinThreads(MAX_REQS, MAX_REQS);
    
                Console.WriteLine("Testing using GetStringAsync");
                RunTest(TestWithGetStringAsync);
                Console.ReadLine();
    
                Console.WriteLine("Testing using GetStringSync");
                RunTest(TestWithGetStringSync);
                Console.ReadLine();
            }
        }
    }
