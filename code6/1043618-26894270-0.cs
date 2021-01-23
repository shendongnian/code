    public async Task<string> SendCredentials()
    {
    	string url = @"https://some.site.com/gettoken";
    	string credentials = "username=super&password=secret";
    	using(var client = new HttpClient())
    	{
    		var response = await client.PostAsync(url, new StringContent(credentials));
    		return await response.Content.ReadAsStringAsync();
    	}
    }
