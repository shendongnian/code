    public OutputBase GetResponse(Type type, params object[] args)
    {
    	if (typeof(type) == typeof(AInput) || typeof(type) == typeof(BInput))
    	{
    		// Return object of type XOutput which inherits OutputBase here.
    		var ret = new XOutput();
    		return ret;
    	}
    	
    	if (typeof(type) == typeof(CInput) || typeof(type) == typeof(DInput))
    	{
    		// Return stuff of type YOutput here.
    		var ret = new YOutput();
    		return ret;
    	}
    	
    	return new ErrorOutput();
    }
