    public async Task CollectData()
    {
    	var tasks = new List<Task>();
    	using (var client = new HttpClient())
    	{
    		foreach (string address in addresses)
    		{
    			tasks.Add(ExecuteSingleRequest(client, address));
    		}
    
    		await Task.WhenAll(tasks.ToArray());
    	}
    }
    
    private async Task ExecuteSingleRequest(HttpClient client, Uri uri)
    {
    	try
    	{
    		var response = await client.GetAsync(uri);
    	}
    	catch (Exception ex)
    	{
    		//This is lazy example code, do real error handling here and don't catch Exception
    	}
    }
