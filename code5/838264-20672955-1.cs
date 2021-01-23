    public class TrippleDictionary<TKey, TValue> 
	{
		Dictionary<TKey, Dictionary<TKey, Dictionary<TKey, TValue>>> dict = new Dictionary<TKey, Dictionary<TKey, Dictionary<TKey, TValue>>>();
		
		public TValue this [TKey key1, TKey key2, TKey key3] 
		{
			get 
			{
				CheckKeys(key1, key2, key3);
				return dict[key1][key2][key3]; 
			}
			set
			{
				CheckKeys(key1, key2, key3);
				dict[key1][key2][key3] = value;
			}
		}
		
		void CheckKeys(TKey key1, TKey key2, TKey key3)
		{
			if (!dict.ContainsKey(key1))
				dict[key1] = new Dictionary<TKey, Dictionary<TKey, TValue>>();
			
			if (!dict[key1].ContainsKey(key2))
				dict[key1][key2] = new Dictionary<TKey, TValue>();
			
			if (!dict[key1][key2].ContainsKey(key3))
				dict[key1][key2][key3] = default(TValue);
		}
    }    
