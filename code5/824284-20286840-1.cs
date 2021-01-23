    private static YourObject data;
    private static object syncObject = new object();
    
    public static YourObject Data
    {
      get
    	{
    		if (data == null)
    		{
    			lock (syncObject)
    			{
    				if (data != null)
    					return data;
    				
    				var obj = new YourObject();
    				
    				return (YourObject)Interlocked.Exchange(ref data, obj);
    			}
    		}
    		
    		return data;
    	}
    }
