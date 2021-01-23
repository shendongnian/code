    const int MAX_DOWNLOADS = 50;
    static async Task DownloadAsync(string[] urls)
    {
        using (var semaphore = new SemaphoreSlim(MAX_DOWNLOADS))
        using (var httpClient = new HttpClient())
        {
            var tasks = urls.Select(async url => 
            {
                await semaphore.WaitAsync();
                try
                {
                    var data = await httpClient.GetStringAsync(url);
                    Console.WriteLine(data);
                }
                finally
                {
                    semaphore.Release();
                }
            });
            await Task.WhenAll(tasks);
        }
    }
