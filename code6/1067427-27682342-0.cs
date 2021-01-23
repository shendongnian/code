        static void Main(string[] args)
        {
            List<string> URLsToProcess = new List<string>()
            {
                "http://www.microsoft.com",
                "http://www.stackoverflow.com",
                "http://www.google.com",
                "http://www.apple.com",
                "http://www.ebay.com",
                "http://www.oracle.com",
                "http://www.gmail.com",
                "http://www.amazon.com",
                "http://www.yahoo.com",
                "http://www.msn.com"
            };
            SemaphoreSlim ss = new SemaphoreSlim(3); //limit 3 threads at a time
            List<Task<string>> tURLs = new List<Task<string>>();
            foreach (string url in URLsToProcess)
            {
                //Task<string> t = DownloadStringAsTask(new Uri(url));
                //tURLs.Add(t);
                tURLs.Add((Task<string>)Task.Run(() =>
                {
                    DownloadStringAsTask(new Uri(url));
                    ss.Release();
                }));
            }
            Console.WriteLine("waiting now");
            Task.WaitAll(tURLs.ToArray());
            Console.WriteLine("download all done");
            foreach (Task<string> t in tURLs)
                Console.WriteLine(t.Result);
            Console.ReadLine();
        }
        
      
        static Task<string> DownloadStringAsTask(Uri address)
        {
            TaskCompletionSource<string> tcs =
              new TaskCompletionSource<string>();
            WebClient client = new WebClient();
            client.DownloadStringCompleted += (sender, args) =>
            {
                if (args.Error != null)
                    tcs.SetException(args.Error);
                else if (args.Cancelled)
                    tcs.SetCanceled();
                else
                    tcs.SetResult(args.Result);
            };
            
            client.DownloadStringAsync(address);
            
            return tcs.Task;
        }
    }
