    public class MyModel
    {
    	public int NumberRequested { get; set; }
    	
    	// This constructor will be called by MVC
    	public MyModel()
    	{
    		RefreshReport();
    	}
    	
    	// Call this constructor explicitly from the controller
    	public MyModel(bool load)
    	{
    		if (!load)
    		{
    			return;
    		}
    		
    		NumberRequested = 10;
    		
    		RefreshReport();
        }
        
        public void RefreshReport()
        {
        	// Do something
        }
    }
    
