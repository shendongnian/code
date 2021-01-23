    public async Task<string> GetWebsiteInfoAsync(URLRequest request)
    {
        System.Net.WebClient wc = new System.Net.WebClient();
        string result = null;
        request.Result = await wc.DownloadStringTaskAsync(new Uri(request.Url));
        return request.result;
    }
