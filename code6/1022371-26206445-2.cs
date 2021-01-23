    public async Task Download(string[] urls)
    {
        var tasks = new List<Task>();
        for(int i = 0; i < urls.Length; i++);
        {
            tasks.Add(DownloadHelper.DownloadAsync(urls[i], @"C:\" + i.ToString() + ".mp3"));
        }
        
        await Task.WhenAll(tasks);
    }
