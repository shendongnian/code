    public class MyObject
    {
    	public DateTime SomeValueUpdated { get; private set; }
    
    	private double _SomeValue;
    	public double SomeValue
    	{
    		get
    		{
    			return _SomeValue;
    		}
    		set
    		{
    			SomeValueUpdated = DateTime.Now;
    			_SomeValue = value;
    		}
    	}
    	
    	public MyObject()
    	{
    	
    	}
    	
    	//for deserialization purposes only
    	public MyObject(double someValue, DateTime someValueUpdated)
    	{
    		this.SomeValue = someValue;
    		this.SomeValueUpdated = someValueUpdated;
    	}
    }
