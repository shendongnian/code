    public Task FetchAndReturnAsync(string url)
    {
    	var httpClient = new HttpClient();
    	return httpClient.GetAsync(url);
    }
