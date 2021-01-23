    private async Task<string> TestTask()
    {
    	Service1Client proxy = null;
    
    	try
    	{
    		Console.WriteLine("Calling service");
    
    		proxy = new Service1Client();
    		return await proxy.DoWorkAsync();
    	}
    	finally
    	{
    		if (proxy.State != System.ServiceModel.CommunicationState.Faulted)
    		{
    			Console.WriteLine("Closing client");
    			proxy.ChannelFactory.Close();
    			proxy.Close();
    		}
    		else
    		{
    			Console.WriteLine("Aborting client");
    			proxy.Abort();
    		}
    	}
    }
