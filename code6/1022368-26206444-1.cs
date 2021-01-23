    public async void Download(string[] urls)
    {
        //you might want to raise the connection limit, 
        //in case these are all from a single host (defaults to 6 per host)
        foreach(var url in urls)
        {
            ServicePointManager
                .FindServicePoint(new Uri(url)).ConnectionLimit = 1000;
        }
        var tasks = urls
             .Select(url =>
                 DownloadHelper.DownloadAsync(
                     url,
                     @"C:\" + i.ToString() + ".mp3"))
             .ToList();
        await Task.WhenAll(tasks);
    }
