    public class AddRangeTo<TKey, TValue> : IEnumerable
    {
    	private readonly IDictionary<TKey, TValue> WrappedDictionary;
    	
    	public AddRangeTo(IDictionary<TKey, TValue> wrappedDictionary)
    	{
    		this.WrappedDictionary = wrappedDictionary;
    	}
    	
    	public void Add(TKey key, TValue value)
    	{
    		this.WrappedDictionary.Add(key, value);
    	}
    	
    	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    	{
       		throw new NotSupportedException();
    	}
    }
