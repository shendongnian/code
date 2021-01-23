    public void SomeOperation(MyObject param)
    {
       //do something
    }
    
    public void SomeOtherOperation(AnotherObject param)
    {
       //do something else
    }
    
    public void SafelyExecute<TParam>(Action<TParam> methodToExecute,
                                      Action<Exception> exceptionHandler,
                                      TParam param)
    {
    	try
    	{
    		methodToExecute(param);
    	}
    	catch (Exception e)
    	{
    		exceptionHandler(e);
    	}
    }
    
    public void DoWork()
    {
       SafelyExecute(SomeOperation,
                     e => div.innerHTML += "there was a problem" + e.Message,
                     myObjectInstance);
       SafelyExecute(SomeOtherOperation,
                     e => div.innerHTML += "there was a different problem" + e.Message,
                     anotherObjectInstance);
    }
