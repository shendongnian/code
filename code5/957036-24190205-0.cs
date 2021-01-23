    private async Task<string> DownloadString()
    {
        var request = (HttpWebRequest)WebRequest.Create(new Uri("linkhere", UriKind.Absolute));
        request.Method = "POST";
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.5 (KHTML, like Gecko) Chrome/19.0.1084.52 Safari/536.5Accept: */*";
        request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        using (var response = (HttpWebResponse)(await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, TaskCreationOptions.None)))
        using (var streamResponse = new StreamReader(response.GetResponseStream()))
        {
            return await streamResponse.ReadToEndAsync();
        }
    }
