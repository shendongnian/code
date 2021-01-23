    class InterlockedLock
    {
    	private int locked;
    	
    	public void Lock()
    	{
    		while (Interlocked.CompareExchange(ref locked, 1, 0) != 0)
    			continue; // spin
    	}
    	
    	public void Unlock()
    	{
    		locked = 0;
    	}
    }
