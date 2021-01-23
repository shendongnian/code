    [HttpPost]
    public StdResponse Test([FromBody]StdRequest request)
    {
    	if (ModelState.IsValid)
    	{
    		//Work on the data from the request...
    	}
    	else
    	{
    		//Retrieve the exceptions raised during deserialization
    		var errors = ModelState.SelectMany(v => v.Value.Errors.Select(e => e.Exception));
		
            List<String> messages = new List<string>();
    
    		foreach (Exception e in errors)
    		{
    			messages.Add(e.GetType().ToString() + ": " + e.Message);
    		}
    
    		return new StdResponse(exchangeVersion, "null", ExecutionResponse.WithError("StdRequest invalid", messages));
    	}
    }
