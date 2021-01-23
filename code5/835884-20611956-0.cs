    public class LazyLookup<TKey, TValue> : IEnumerable<List<TValue>>
    {
       private readonly Dictionary<TKey, List<TValue>> CachedEntries;
       private readonly Func<List<TValue>> LazyListCreator;
    
    	public LazyLookup()
    		: this(() => new List<TValue>())
    	{
    	
    	}
    	public LazyLookup(Func<List<TValue>> lazyListCreator)
    	{
    		this.LazyListCreator = lazyListCreator;
    		this.CachedEntries = new Dictionary<TKey, List<TValue>>();
    	}
    	
    	public List<TValue> this[TKey key]
    	{
    		get
    		{
    			return GetOrCreateValue(key);
    		}
    	}
    	
    	private List<TValue> GetOrCreateValue(TKey key)
    	{
    		List<TValue> returnValue;
    		if (!CachedEntries.TryGetValue(key, out returnValue))
    		{
    			returnValue = LazyListCreator();
    			CachedEntries[key] = returnValue;
    		}
    		return returnValue;
    	}
    	
    	public IEnumerator<List<TValue>> GetEnumerator()
    	{
    		return CachedEntries.Values.GetEnumerator();
    	}
    	
    	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    	{
    		return GetEnumerator();
    	}
    }
