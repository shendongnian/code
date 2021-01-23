    public async static Task<byte[]> getData(string url)
    {
        bool success = false;
    
        byte[] dataBytes = null;
    	while (!success)
    	{				
    		try
    		{
    			Uri uri = new Uri(url);
    
    			var client = new HttpClient();
    			var response = await client.GetAsync(uri);
    			response.EnsureSuccessStatusCode();
    
    			var stream = await response.Content.ReadAsStreamAsync();
    			dataBytes = getDataBytes(stream); 
    
    			success = dataBytes != null && dataBytes.Length > 0;
    		}
    		catch (HttpRequestException)
    		{
    		}
    	}
    
        return dataBytes;
    }
