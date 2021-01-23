    try
    {
    	var httpClient = new HttpClient();
    	httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
    	HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, URL);
    	req.Content = new StringContent(doc.ToString(), Encoding.UTF8, "text/xml");
    	await httpClient.SendAsync(req).ContinueWith(async respTask =>
    	{
    		Debug.WriteLine(req.Content.ReadAsStringAsync());
    	};
    }
    catch (Exception ex) 
    { 
    }
