    public async Task<string> PostAsync(string uri, string data, string contentType, string method = "POST", Action<WebHeaderCollection> headers = null)
    {
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
    
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        headers?.Invoke(request.Headers);
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
        request.ContentLength = dataBytes.Length;
        request.ContentType = contentType;
        request.Method = method;
    
        using(Stream requestBody = request.GetRequestStream())
        {
            await requestBody.WriteAsync(dataBytes, 0, dataBytes.Length);
        }
    
        using(HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
        using(Stream stream = response.GetResponseStream())
        using(StreamReader reader = new StreamReader(stream))
        {
            return await reader.ReadToEndAsync();
        }
    }
