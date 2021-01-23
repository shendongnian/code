    public class UniqueId<T>
    	where T:class
    {
    	long counter = 0;
    	object _lock = new object();
    	ConditionalWeakTable<T,object> ids = new ConditionalWeakTable<T,object>();
    	
    	public long GetId(T obj)
    	{
    		return (long)ids.GetValue(obj, _ => Interlocked.Increment(ref counter));
    	}
    }
