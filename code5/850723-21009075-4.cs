    private async Task<List<string>> DownloadSomething(
        string url, 
        IProgress<int> progress, 
        CancellationToken token)
    {
        var System.Net.WebRequest.Create(url);
    
        // ...
    
        using (var ss = await request.GetRequestStreamAsync())
        { 
            await ss.WriteAsync(...);
        }
    
        using (var rr = await request.GetResponseAsync())
        using (var ss = rr.GetResponseStream())
        {
            //read stream and return data
        }
    }
    // ...
    // Calling it DownloadSomething from the UI thread via Task.Run:
    var progressIndicator = new Progress<int>(ReportProgress);
    var cts = new CancellationTokenSource(30000); // cancel in 30s (optional)
    var url = "https://valid.url";
    // result type is inferred to List<string> by the compiler 
    var result = await Task.Run(() => 
        DownloadSomething(url, progressIndicator, cts.Token), cts.Token);
