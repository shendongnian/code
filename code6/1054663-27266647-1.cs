        public static List<int> List = new List<int>(); 
        public static async Task AddToList(CancellationToken cancellation)
        {
            List.Clear();
            for (var i = 0; i < 100 && !cancellation.IsCancellationRequested; i++)
            {
                await Task.Delay(100, cancellation);
                List.Add(i);
            }
        }
        public static async Task MainAsync(CancellationToken cancellation)
        {
            await AddToList(cancellation);
        }
        private static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            Task.Run(() => MainAsync(cts.Token), cts.Token);
            Thread.Sleep(1000);
            cts.Cancel();
            cts = new CancellationTokenSource();
            Task.Run(() => MainAsync(cts.Token), cts.Token).Wait(cts.Token);
            
            Console.WriteLine(List.Count);
            Console.Read();
        }
