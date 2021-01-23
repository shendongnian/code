    private async Task<List<string>> DownloadSomething()
    {
        var request = await Task.Run(() => {
            // WebRequest.Create freezes??
            return System.Net.WebRequest.Create("https://valid.url");
        });
    
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
