    public class DataContextManager
    {
    	private readonly string connectionToUse = string.Empty;
    
    	private Entities _context;
    	
    	public Entities Context
    	{
    		get
    		{
    			if (_context == null)
    			{
    				_context = new Entities(WebConfigurationManager.ConnectionStrings[connectionToUse].ConnectionString);
    			}
    
    			return _context;
    		}
    	}
    	
    	public DataContextManager()
    	{
    		connectionToUse = "connString";
    	}
    	
    	public DataContextManager(string key)
    	{
    		connectionToUse = key;
    	}
    	
    
    	#region IDisposable Members
    
    	public void Dispose()
    	{
    		this.Dispose(true);
    
    		GC.SuppressFinalize(this);
    	}
    
    	protected virtual void Dispose(bool disposeAll)
    	{
    		if (disposeAll)
    		{
    			_context.Dispose();
    		}
    		_context = null;
    	}
    
    	#endregion
    }
