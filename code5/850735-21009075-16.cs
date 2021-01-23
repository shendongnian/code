    private async Task<List<string>> DownloadSomething(
        string url, 
        IProgress<int> progress, 
        CancellationToken token)
    {
        var request = System.Net.WebRequest.Create(url);
    
        // ...
    
        using (var ss = await request.GetRequestStreamAsync())
        { 
            await ss.WriteAsync(...);
        }
    
        using (var rr = await request.GetResponseAsync())
        using (var ss = rr.GetResponseStream())
        {
            // read stream and return data
            progress.Report(...); // report progress  
        }
    }
    // ...
    // Calling DownloadSomething from the UI thread via Task.Run:
    var progressIndicator = new Progress<int>(ReportProgress);
    var cts = new CancellationTokenSource(30000); // cancel in 30s (optional)
    var url = "https://valid.url";
    var result = await Task.Run(() => 
        DownloadSomething(url, progressIndicator, cts.Token), cts.Token);
    // the "result" type is deduced to "List<string>" by the compiler 
