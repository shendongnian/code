    public abstract class Base<TKey>
    {
    	public Base(TKey key) { }
    }
    
    public class ImplA : Base<string>
    {
    	public ImplA(string key) : base(key) {}
    }
    
    public class MyCache<TBase, TKey> where TBase : Base<TKey>
    {
        public TBase Get(TKey key)
    	{
    		return (TBase)Activator.CreateInstance(typeof(TBase), key);
    	}
    }
