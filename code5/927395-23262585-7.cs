    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace NoAsync
    {
        internal class Program
        {
            private const int totalCalls = 100;
    
            private static void Main(string[] args)
            {
                var tasks = new List<Task>();
    
                for (int i = 1; i <= totalCalls; i++)
                    tasks.Add(Task.Run(() => GoogleSearch(i)));
    
                Task.WaitAll(tasks.ToArray());
            }
    
            private static void GoogleSearch(object searchTerm)
            {
                string url = @"https://www.google.com/search?q=" + searchTerm;
                Console.WriteLine("Total number of threads in use={0}", Process.GetCurrentProcess().Threads.Count);
                WebRequest wr = WebRequest.Create(url);
                var httpWebResponse = (HttpWebResponse)wr.GetResponse();
                var reader = new StreamReader(httpWebResponse.GetResponseStream());
                string responseFromServer = reader.ReadToEnd();
                //Console.WriteLine(responseFromServer); // Display the content.
                httpWebResponse.Close();
                Console.WriteLine("Total number of threads in use={0}", Process.GetCurrentProcess().Threads.Count);
            }
        }
    }
