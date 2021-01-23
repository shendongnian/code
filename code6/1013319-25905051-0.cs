    public bool Processing { get; set; }
    
    private void Process(Action process)
    {
    	Processing = true;
    	process();
    	Processing = false;
    }
    
    public void Load()
    {
    	//Logic to load the data
    }
    
    public void Save()
    {
    	//Logic to save the data
    }
