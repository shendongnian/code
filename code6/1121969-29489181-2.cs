    async Task<IEnumerable<string>> DoItAsync(int threads, IEnumerable<string> urls)
    {
        ServicePointManager.DefaultConnectionLimit = 12*Environment.ProcessorCount;
        Console.WriteLine("{0:HH:mm:ss.ffffff}\t{1}", DateTime.Now, ServicePointManager.DefaultConnectionLimit);
        
        var semaphore = new SemaphoreSlim(threads);
        var client = new HttpClient();
        var cnt = 0;
        var tasks = new List<Task<string>>();
        foreach (var url in urls)
        {
            tasks.Add(((Func<Task<string>>)(async () =>                {
                    await semaphore.WaitAsync();
                    
                    var c = ++cnt;
                    Console.WriteLine("{0:HH:mm:ss.ffffff}\t{1}\t{2}", DateTime.Now, c, url);
                    var s = await client.GetStringAsync(url);
                    Console.WriteLine("{0:HH:mm:ss.ffffff}\t{1}\t{2}\t{3}", DateTime.Now, c, url, s.Substring(0, 20));
                    semaphore.Release();
                    return s;
                }))());        }
        
        return await Task.WhenAll(tasks);
    }
