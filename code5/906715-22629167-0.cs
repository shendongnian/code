    public class ExpiringSessionValue<T>
    {
    	private T _value;
    	private DateTime _created = DateTime.Now;
    
    	public ExpiringSessionValue(T value)
    	{
    		_value = value;
    	}
    
    	public T Value
    	{
    		get
    		{
    			if (_created >= DateTime.Now.AddMinutes(-10))
    				return _value;
    			else
    				return default(T);
    		}
    	}
    }
