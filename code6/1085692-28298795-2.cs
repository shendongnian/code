    public ResponseMessage GetAllUpdates()
    {
    	ResponseMessage response;
    
    	response = GetCountries();
    	if (!response)
    	{
    		return response;
    	}
    
    	response = GetAreas();
    	if (!response)
    	{
    		return response;
    	}
    
    	response = GetCities();
    	if (!response)
    	{
    		return response;
    	}
    
    	response.Result = true;
    	response.Message = "Successful";
    
    	return response;
    }
    
    public ResponseMessage GetCountries()
    {
    	var response = new ResponseMessage();
    
    	try
    	{
    		// Your main code here, call services etc
    
    		response.Result = true;
    		response.Message = "GetCountries successful";
    	}
    	catch (TimeoutException ex)
    	{
    		Log.Error("Web Service Timeout", ex);
    		response.Result = false;
    		response.Message = "Failed to contact web services.";
    	}
    	catch (Exception ex)
    	{
    		Log.Error("Exception", ex);
    		response.Result = false;
    		response.Message = "An error has occurred.";
    	}
    
    	return response;
    }
