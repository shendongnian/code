	using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url);
		
		string content = response.Content.ReadAsStringAsync();
		var statusCode = response.StatusCode;		
    }
