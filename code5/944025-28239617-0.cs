    public bool Start(HostControl hostControl)
    {
    	if (!File.Exists(_xmlFile) 
    	{
    		hostControl.Stop();
    		return true;
    	}
    
    	// Do some work here if xml file exists.
    	...
    }
