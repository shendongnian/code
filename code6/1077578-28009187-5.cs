    public async Task DoGetWebRequestAsync()
    {
    	var httpClient = new HttpClient();
    	await httpClient.GetAsync(url);
    }
