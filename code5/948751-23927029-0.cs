    static async Task RunAsyncGet(string baseUri, string uri)
    {
    	var client = new HttpClient();
    	
    	client.BaseAddress = new Uri(baseUri);
    	HttpResponseMessage response = await client.GetAsync(uri);
    
    	IEnumerable<UserAccountModel> users = await response.EnsureSuccessStatusCode().Content.ReadAsAsync<IEnumerable<UserAccountModel>>();
    	
    	// ... the rest ...
    }
