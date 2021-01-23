    public class MultiKeyDictionary<TKey, TValue> : IDictionary<HashSet<TKey>, TValue>
    {
        private readonly IDictionary<HashSet<TKey>, TValue> _dict;
    
        public MultiKeyDictionary()
        {
            _dict = new Dictionary<HashSet<TKey>, TValue>(HashSet<TKey>.CreateSetComparer());
        }
    
        public TValue this[params TKey[] keys]
        {
            get { return _dict[new HashSet<TKey>(keys)]; }
            set { _dict[new HashSet<TKey>(keys)] = value; }
        }
        
        ...
    }
    var dict = new MultiKeyDictionary<int, string>();
    dict[1, 2] = "foo";
    dict[2, 1].Dump();
