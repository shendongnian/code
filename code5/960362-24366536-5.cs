    class Program
    {        
        static SemaphoreSlim s_sem = new SemaphoreSlim(90, 90);
        static List<Task> s_tasks = new List<Task>();   
        public static void Main()
        {                     
            for (int request = 1; request <= 1000; request++)
            {                             
                var task = FetchData();
                s_tasks.Add(task);                
            }
            Task.WaitAll(s_tasks.ToArray());
        }        
        private static async Task<string> FetchData()
        {
            try
            {
                s_sem.Wait();
                using (var wc = new MyCustomWebClient())
                {
                    string content = await wc.DownloadStringTaskAsync(
                        new Uri("http://www.interact-sw.co.uk/oops/")).ConfigureAwait(continueOnCapturedContext: false);
                    return content;
                }
            }
            finally
            {
                s_sem.Release(1);
            }
        }
        private class MyCustomWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                var req = (HttpWebRequest)base.GetWebRequest(address);
                req.ServicePoint.ConnectionLimit = 30;
                return req;
            }
        }
    }
