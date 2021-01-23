    private async Task<List<string>> DownloadSomething()
    {
        WebRequest request;
        await Task.Run(() => {
            // WebRequest.Create freezes??
            request = System.Net.WebRequest.Create("https://valid.url");
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
