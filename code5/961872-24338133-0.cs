    public async Task<Dictionary<string, T>> DownloadStuff<T>(string url)
    {
        using (var client = new HttpClient())
        using (var stream = await client.GetStreamAsync(url))
        using (var sr = new StreamReader(stream))
        using (var reader = new JsonTextReader(sr))
        {
            var serializer = new JsonSerializer();
            return serializer.Deserialize<Dictionary<string, T>>(reader);
        }
    }
