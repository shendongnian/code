    public class MyClass : IDisposable
    {
        public MyClass()
        {
            log = new EventLog { Source = "MyLogSource", Log="MyLog" };
            FileStream stream = File.Open("MyFile.txt", FileMode.OpenOrCreate);
        }
    
    
        private readonly EventLog log;
        private readonly FileStream stream;
    	
    	public void Dispose()
    	{
    		Dispose(true);
    	}
    	
    	protected virtual void Dispose(bool disposing)
    	{
    		if (disposing)
    		{
    			// Free managed objects here
                stream.Dispose();
    		}
    	}
    
        // Other members, using the fields above
    }
