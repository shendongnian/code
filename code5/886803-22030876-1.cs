    class MultidimensionalArray<TKey, TValue>
    {
        private readonly Dictionary<string, TValue> _impl = new Dictionary<string, TValue>();
    
        public TValue this[IEnumerable<TKey> index]
        {    
            get { return _impl[ToStringKey(index)]; }
            set { _impl[ToStringKey(index)] = value; }
        }
        
        public TValue this[params TKey[] index]
        {
            get { return this[index.AsEnumerable()]; }
            set { this[index.AsEnumerable()] = value; }
        }
    
        private string ToStringKey(IEnumerable<TKey> key)
        {
            return string.Join(";", key.Select(k => k.ToString()));
        }
    }
