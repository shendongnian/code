    public async Task<string> GetAsync(string uri, Action<WebHeaderCollection> headers = null)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        headers?.Invoke(request.Headers);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
    
        using(HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
        using(Stream stream = response.GetResponseStream())
        using(StreamReader reader = new StreamReader(stream))
        {
            return await reader.ReadToEndAsync();
        }
    }
