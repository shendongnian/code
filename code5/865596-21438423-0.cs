    public class MyDict<TKey,TValue> : Dictionary<TKey, TValue> where TValue : new()
    {
        public void Add(TKey key)
        {
           this.Add(key, new TValue());
        }
    }
