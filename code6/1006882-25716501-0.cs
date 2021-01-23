        public static async Task MainAsync()
        {
            var urls = new List<string> {"url1", "url2", "url3", "url4", "url5", "url6"};
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            IEnumerable<Task<MyResults>> tasks =
                from url in urls
                select taskAsync(url).WithCancellation(cts.Token);
            Task<MyResults>[] excutedTasks = null;
            MyResults[] res = null;
            try
            {
                // Execute the query and start the searches:
                excutedTasks = tasks.ToArray();
                res = await Task.WhenAll(excutedTasks);
            }
            catch (Exception exc)
            {
                if (excutedTasks != null)
                {
                    foreach (Task<MyResults> faulted in excutedTasks.Where(t => t.IsFaulted))
                    {
                        // work with faulted and faulted.Exception
                    }
                }
            }
        }
        public static async Task<MyResults> taskAsync(string url)
        {
            Console.WriteLine("Start " + url);
            var random = new Random();
            var delay = random.Next(10);
            await Task.Delay(TimeSpan.FromSeconds(delay));
            Console.WriteLine("End " + url);
            return new MyResults();
        }
        private static void Main(string[] args)
        {
            MainAsync().Wait();
        }
