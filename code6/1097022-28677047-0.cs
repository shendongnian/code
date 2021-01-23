        public class Runner
    {
        private Task<int> search(CancellationToken ct)
        {
            var t_work = Task.Factory.StartNew<int>(() =>
            {
                int k = 0;
                while (k < 1000)
                {
                    if (ct.IsCancellationRequested)
	                {
                        return -1;
	                }                    
                    k += r.Next(200);
                    Thread.Sleep(300);
                }
                return k;
            }, ct);
            return t_work;
        }
        
        Random r = new Random();
        public async Task SearchAsync()
        {
            var timeout = TimeSpan.FromSeconds(3);
            var cts = new CancellationTokenSource(timeout);
            var ct = cts.Token;
            var searchValue = await search(ct);
            string result = (searchValue < 0) ?
                "Search aborted without results" : "search value is: " + searchValue.ToString();
            Console.WriteLine(result);
        }
    }
