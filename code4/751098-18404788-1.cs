    HttpClient client = new HttpClient();
    HttpContent httpContent = new StringContent("my content: xml, json or whatever");
    httpContent.Headers.Add("name", "value");
    
    HttpResponseMessage response = await client.PostAsync("uri", httpContent);
    if (response.IsSuccessStatusCode)
    {
    	// DO SOMETHING
    }
