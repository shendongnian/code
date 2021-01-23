    const int MAX_DOWNLOADS = 50;
    const int MAX_PROCESSORS = 4;
    // process data
    class Processing
    {
        SemaphoreSlim _semaphore = new SemaphoreSlim(MAX_PROCESSORS);
        HashSet<Task> _pending = new HashSet<Task>();
        object _lock = new Object();
        async Task ProcessAsync(string data)
        {
            await _semaphore.WaitAsync();
            try
            {
                await Task.Run(() =>
                {
                    // simuate work
                    Thread.Sleep(1000);
                    Console.WriteLine(data);
                });
            }
            finally
            {
                _semaphore.Release();
            }
        }
        public async Task QueueItemAsync(string data)
        {
            var task = ProcessAsync(data);
            lock (_lock)
                _pending.Add(task);
            await task;
            lock (_lock)
                _pending.Remove(task);
        }
        public async Task WaitForCompleteAsync()
        {
            Task[] tasks;
            lock (_lock)
                tasks = _pending.ToArray();
            await Task.WhenAll(tasks);
        }
    }
    static void FireAndForget(Task task)
    {
        // empty to suppress warning CS4014
        // http://stackoverflow.com/q/22629951/1768303
    }
    // download data
    static async Task DownloadAsync(string[] urls)
    {
        var processing = new Processing();
        using (var semaphore = new SemaphoreSlim(MAX_DOWNLOADS))
        using (var httpClient = new HttpClient())
        {
            var tasks = urls.Select(async (url) =>
            {
                await semaphore.WaitAsync();
                try
                {
                    var data = await httpClient.GetStringAsync(url);
                    // put it on the processing pipeline
                    FireAndForget(processing.QueueItemAsync(data));
                }
                finally
                {
                    semaphore.Release();
                }
            });
            await Task.WhenAll(tasks.ToArray());
            await processing.WaitForCompleteAsync();
        }
    }
