    public static async Task<string> GetUrlAsync(string url)
    {
        using (var client = new HttpClient())
        {
            return await client.GetStringAsync(url);
        }
    }
    public static async Task<string> GetUrl2Async(string url)
    {
        using (var client = new WebClient())
        {
            return await client.DownloadStringTaskAsync(url);
        }
    }
