    class Test : IDisposable
    { 
        public Font Font { get; set; }  
    	
        public Test()
        {
            Font = new Font("Arial", 16, FontStyle.Bold);                   
        }
    	
    	public void Dispose()
    	{
    		Dispose(true);
    	}
    	
    	protected virtual void Dispose(bool disposing)
    	{
    		if (disposing)
    		{
    			Font.Dispose();
    		}
    	}
    }
