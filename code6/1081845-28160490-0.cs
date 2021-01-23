    private Object thisLock = new Object();
        
    public void Update()
    {
    	lock (thisLock)
    	{
    		//Code to lock here
    	}
    }
