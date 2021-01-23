    public async Task<string> SendRequest(this string url)
    {
        using (var wc = new WebClient())
        {
            var bytes = await wc.DownloadDataTaskAsync(url);
            using (var reader = new StreamReader(new MemoryStream(bytes)))
                return await reader.ReadToEndAsync();
        }
    }
