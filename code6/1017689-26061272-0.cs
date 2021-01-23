    var client = new System.Net.WebClient();
    await Task.WhenAll(urls.Select(url => {
        var path = ?? // build local path based on url?
        return client.DownloadFileAsync(url, path);
    });
