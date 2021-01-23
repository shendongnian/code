    class Program
    {
        static IEnumerable<site> list = Enumerable.Range(1, 10).Select(i => new site(i.ToString()));
        static void Main(string[] args)
        {
            Startup().Wait();
            Console.ReadKey();
        }
        static async Task Startup()
        {
            while (true)
            {
                router.cts = new CancellationTokenSource();
                
                await Task.WhenAll(list.Select(s => Update(s)));
            }
        }
        static Task Update(site s)
        {
            if (site.count % 4 == 0)
            {
                Console.WriteLine("Reseting Queue");
                router.cts.Cancel();
            }
            else
            {
                return s.Refresh();
            }
        }
    }
    class router
    {
        public static SemaphoreSlim ss = new SemaphoreSlim(1);
        public static CancellationTokenSource cts { get; set; }
    }
    class site
    {
        public static int count = 0;
        public string sitename {get; set;}
        public site(string s)
        {
            sitename = s;
        }
        public async Task Refresh()
        {
            await router.ss.WaitAsync();
            try
            {
                if (router.cts.token.IsCancellationRequested)
                {
                    return;
                }
                await Task.Delay(500);
               
                if (router.cts.token.IsCancellationRequested)
                {
                    return;
                }
                await Task.Delay(500);
                Console.WriteLine("{0}:: Done Refreshing ", sitename);
                count++;
            }
            finally
            {
                router.ss.Release();
            }
        }
    }
