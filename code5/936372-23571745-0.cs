    public async Task<byte[]> DownloadFileAsync(string requestUri)
    {
        // Service URL
        string serviceURL = "http://www.example.com";
		// Http Client Handler and Credentials
		HttpClientHandler httpClientHandler = new HttpClientHandler();
		httpClientHandler.Credentials = new NetworkCredential(username, passwd, domain);
			
        // Initialize Client
        HttpClient client = new HttpClient(httpClientHandler)
        client.BaseAddress = new Uri(serviceURL);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/bson"));
		// Add Range Header
		client.DefaultRequestHeaders.Add("Range", "bytes=0-");
        // Deserialize
        MemoryStream result = new MemoryStream();
        Stream stream = await client.GetStreamAsync(requestUri);
        await stream.CopyToAsync(result);
        result.Seek(0, SeekOrigin.Begin);
		
		// Bson Reader
        byte[] output = null;
        using (BsonReader reader = new BsonReader(result))
        {
            var jsonSerializer = new JsonSerializer();
            output = jsonSerializer.Deserialize<byte[]>(reader);
        }
        return output;
    }
