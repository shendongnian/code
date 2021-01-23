    public Task UploadAsync()
    {
    	while(true)
    	{
    		await Task.Delay(1000); // this is essentially your timer
    		
    		// wait for the webTask to complete asynchrnously
    		await webTask;
    		
    		//keep count of competed tasks
    		
    		webTask = Task.Run(() =>
    						{
    							try 
    							{ 
                                    // consider generating an asynchronous method for this if possible.
    								wcf.UploadMotionDynamicRaw(bytes);  //my web service
    							}
    							catch (Exception ex)
    							{
    								//deal with error
    							}
    						});		
    	}
    }
