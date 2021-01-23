    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace Console_21690385
    {
        class Program
        {
            static async Task TestAsync()
            {
                var httpClient = new HttpClient();
    
                var tasks = Enumerable.Range(1, 500).Select((i) =>
                    httpClient.GetStringAsync("http://example.com?i=" + i));
    
                Console.WriteLine("Threads before completion: " + Process.GetCurrentProcess().Threads.Count);
    
                await Task.WhenAll(tasks);
    
                Console.WriteLine("Threads after completion: " + Process.GetCurrentProcess().Threads.Count);
            }
    
            static void Main(string[] args)
            {
                Console.WriteLine("Threads at start: " + Process.GetCurrentProcess().Threads.Count);
    
                var testTask = TestAsync();
    
                while (!testTask.IsCompleted)
                {
                    Console.WriteLine("Currently threads: " + Process.GetCurrentProcess().Threads.Count);
                    Thread.Sleep(250);
                }
    
                testTask.Wait();
                Console.ReadLine();
            }
        }
    }
