    class MyClass : IDisposable
    {
    	private bool alreadyDisposed = false;
    	
    	public void Dispose()
    	{
    		Dispose(true);
    		GC.SuppressFinalize(this);
    	}
    
    	// This is called by GC automatically at some point if public Dispose() has not already been called
    	~MyClass()
    	{
    		Dispose(false);
    	}
    
    	// Each derived class should implement this method and conclude it with base.Dispose(disposeManagedResourcesAlso)) call
    	protected virtual void Dispose(bool disposeManagedResourcesAlso)
    	{
    		if (alreadyDisposed) return;
    		
    		if (disposeManagedResourcesAlso)
    		{
    			...dispose managed resources...
    		}
    
    		...dispose unmanaged resources...
    
    		alreadyDisposed = true;	
    	}
    }
