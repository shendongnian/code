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
        public async void QueueItemAsync(string data)
        {
            var task = ProcessAsync(data);
            lock (_lock)
                _pending.Add(task);
            try
            {
                await task;
            }
            catch
            {
                if (!task.IsCanceled && !task.IsFaulted)
                    throw; // not the task's exception, rethrow
                // don't remove faulted/cancelled tasks from the list
                return;
            }
            // remove successfully completed tasks from the list 
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
                    // put the result on the processing pipeline
                    processing.QueueItemAsync(data);
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
