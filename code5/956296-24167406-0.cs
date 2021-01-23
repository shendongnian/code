    public class CacheEntry<T>
    {
    	public T Value { get; private set; }
    
    	public CacheEntry(T value)
    	{
    		Value = value;
    	} 
    }
