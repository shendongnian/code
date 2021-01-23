    private class DictionaryQueryHolder<TKey, TValue> : IQueryable<KeyValuePair<TKey, TValue>>
    {
        public IDictionary<TKey, TValue> Dictionary { get; private set; }
        private IQueryable<KeyValuePair<TKey, TValue>> Queryable { get; set; }
    
        internal DictionaryQueryHolder(IDictionary<TKey, TValue> dictionary)
        {
            Dictionary = dictionary;
            Queryable = dictionary.AsQueryable();
        }
    
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Queryable.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
        public Expression Expression
        {
            get { return Queryable.Expression; }
        }
    
        public Type ElementType
        {
            get { return Queryable.ElementType; }
        }
    
        public IQueryProvider Provider
        {
            get { return Queryable.Provider; }
        }
    }
