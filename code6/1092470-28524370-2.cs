    public async Task GetAsync()
    {
    	var expirationTimeTask = Task.Delay(TimeSpan.FromMinutes(30));
    	var responseTask = client.GetAsync("ladders/get/ " + ID);
    	
    	var finishedTask = await Task.WhenAny(expirationTimeTask, responseTask);
    	if (finishedTask == expirationTimeTask)
    	{
    		// If we get here, the timer passed 30 minutes
    	}
    	else
    	{
    		// If we get here, we got a response message first.
    		if (responseTask.IsSuccessStatusCode)
    		{
    			string result = await responseTask.Content.ReadAsStringAsync();
    		}	
    	}
    }
