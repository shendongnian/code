    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    namespace AsyncAwait
    {
        internal class Program
        {
            private const int totalCalls = 100;
    
            private static void Main(string[] args)
            {
                var tasks = new List<Task>();
    
                for (int i = 1; i <= totalCalls; i++)
                {
                    var searchTerm = i;
                    var t = GoogleSearch(searchTerm);
                    tasks.Add(t);
                }
    
                Task.WaitAll(tasks.ToArray());
                Console.WriteLine("Hit Enter to exit");
                Console.ReadLine();
            }
    
            private static async Task GoogleSearch(object searchTerm)
            {
                Thread.CurrentThread.IsBackground = false;
                string url = @"https://www.google.com/search?q=" + searchTerm;
                Console.WriteLine("Total number of threads in use={0}", Process.GetCurrentProcess().Threads.Count);
                using (var client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        HttpContent content = response.Content;
                        content.Dispose();
                        Console.WriteLine("Total number of threads in use={0}", Process.GetCurrentProcess().Threads.Count);
                    }
                }
            }
        }
    }
