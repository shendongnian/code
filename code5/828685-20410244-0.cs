    private void Test(bool b)
    {
    	if(! b)
    	{
    		//do something
    	}
    }
    
    private void Test<T>(T value) where T : class
    {
    	if(value == null)
    	{
    		//do something else
    	}
    }
