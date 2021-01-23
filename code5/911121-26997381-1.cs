    public class MyEventArgs : MarshalByRefWrapper<EventArgs>
    {
    	public DataTable SystemState { get; set; }
    	public string SystemString { get; set; }
    }
    
    public class MarshalByRefWrapper<T> : MarshalByRefObject
    {
    	public MarshalByRefWrapper()
    	{
    
    	}
    
    	public MarshalByRefWrapper(T value)
    	{
    		Value = value;
    	}
    
    	public T Value { get; set; }
    
    	public static implicit operator MarshalByRefWrapper<T>(T value)
    	{
    		return new MarshalByRefWrapper<T>(value);
    	}
    }
