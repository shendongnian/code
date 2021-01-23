    class XDict : Hashtable
    {
    	public override void Add(object key, object value)
    	{
    		if (key.Equals("something"))
    		{
    			// ...
    		}
    		else
    		{
    			base.Add(key, value);
    		}
    	}
    
    }
