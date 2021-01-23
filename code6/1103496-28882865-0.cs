    public async Task<string> SendRequest(this string url)
    {
        var wc = new WebClient();
        wc.DownloadDataCompleted += async (s, e) => <--- see here
        {
            var buffer = e.Result;
            using (var sr = new StreamReader(new MemoryStream(buffer)))
            {
                var result = await sr.ReadToEndAsync();
            };
        };
        wc.DownloadDataAsync(new Uri(url));
    }
