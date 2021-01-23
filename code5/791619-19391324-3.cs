    // non-blocking async method
    async Task<string> ProcessUrlAsync(string url)
    {
        using (var webClient = new WebClient())
        {
            string data = await webClient.DownloadStringTaskAsync(new Uri(url));
            // run checks here.. 
            return data;
        }
    }
    
    // ...
    
    if (ListOfUrls.Count > 0) {
        var tasks = new List<Task>();
        foreach (var url in ListOfUrls)
        {
          var webClient = new WebClient();
          tasks.Add(ProcessUrlAsync(url));
        }
        Task.WaitAll(tasks.ToArray()); // blocking wait
        // could use await here and make this method async:
        // await Task.WhenAll(tasks.ToArray());
    }
