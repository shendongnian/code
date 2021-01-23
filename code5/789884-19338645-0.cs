    async Task AccessTheWebAsync(CancellationToken ct)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
    
        var downloadTasks = new List<Task<Tuple<string, int>>();
    
        int index = 0;
        foreach(var url in URLList)
        	downloadTasks.Add(ProcessURL(url, client, ct, index++));
    
        while (downloadTasks.Count > 0)
        {
            Task<Tuple<string, int>> firstFinishedTask = await Task.WhenAny(downloadTasks);
    
            downloadTasks.Remove(firstFinishedTask);
    
            string length = await firstFinishedTask;  //this is the data of the first finished download
            int refPoint = length.IndexOf("Download (Save as...): <a href=\"") + 32;
            VideoList.Add(length.Substring(refPoint, length.IndexOf("\">", refPoint) - refPoint));
        }
    }
    
    async Task<Tuple<string, int>> ProcessURL(string url, HttpClient client, CancellationToken ct, int index)
    {
        HttpResponseMessage response = await client.GetAsync(url, ct);
        string urlContents = await response.Content.ReadAsStringAsync();
        return Tuple.Create(urlContent, index);
    }
