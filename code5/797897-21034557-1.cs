    protected DataContextManager Manager = null;
    
    public HomeController()
    {
    	Manager = new DataContextManager();
    	
    	// or
    	//
    	//__manager = new DataContextManager("connection-To-Use");
    }
