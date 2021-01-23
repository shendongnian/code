    public class MyCustomDictionary<TKey,TVal>:IDictionary<TKey,TVal>
    {
        private Dictionary<TKey, TVal> dictionary;
        public MyCustomDictionary()
        {
            dictionary=new Dictionary<TKey, TVal>();
        }
        public void CopyTo(Array array, int index)
        {
            ((ICollection) dictionary).CopyTo(array, index);
        }
        public object SyncRoot
        {
            get { return ((ICollection) dictionary).SyncRoot; }
        }
        public bool IsSynchronized
        {
            get { return ((ICollection) dictionary).IsSynchronized; }
        }
        public bool Contains(object key)
        {
            return ((IDictionary) dictionary).Contains(key);
        }
        public void Add(object key, object value)
        {
            ((IDictionary) dictionary).Add(key, value);
        }
        public void Remove(object key)
        {
            ((IDictionary) dictionary).Remove(key);
        }
        public object this[object key]
        {
            get { return dictionary[(TKey) key]; }
            set { dictionary[(TKey) key] = (TVal) value; }
        }
        public bool IsFixedSize
        {
            get { return ((IDictionary) dictionary).IsFixedSize; }
        }
        public void Add(TKey key, TVal value)
        {
            dictionary.Add(key, value);
        }
        public void Clear()
        {
            dictionary.Clear();
        }
        public bool Contains(KeyValuePair<TKey, TVal> item)
        {
            TVal v;
            return (dictionary.TryGetValue(item.Key, out v) && v.Equals(item.Key));
        }
        public void CopyTo(KeyValuePair<TKey, TVal>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<TKey, TVal>>)dictionary)
                .CopyTo(array,arrayIndex);
        }
        public bool Remove(KeyValuePair<TKey, TVal> item)
        {
            if (Contains(item))
            {
                dictionary.Remove(item.Key);
                return true;
            }
            return false;
        }
        public bool ContainsKey(TKey key)
        {
            return dictionary.ContainsKey(key);
        }
        public bool ContainsValue(TVal value)
        {
            return dictionary.ContainsValue(value);
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            dictionary.GetObjectData(info, context);
        }
        public void OnDeserialization(object sender)
        {
            dictionary.OnDeserialization(sender);
        }
        public bool Remove(TKey key)
        {
            return dictionary.Remove(key);
        }
        public bool TryGetValue(TKey key, out TVal value)
        {
            return dictionary.TryGetValue(key, out value);
        }
        public IEqualityComparer<TKey> Comparer
        {
            get { return dictionary.Comparer; }
        }
        public int Count
        {
            get { return dictionary.Count; }
        }
        public bool IsReadOnly { get; private set; }
        public TVal this[TKey key]
        {
            get { return dictionary[key]; }
            set { dictionary[key] = value; }
        }
        public ICollection<TKey> Keys
        {
            get { return dictionary.Keys; }
        }
        public ICollection<TVal> Values
        {
            get { return dictionary.Values; }
        }
        public IEnumerator<KeyValuePair<TKey, TVal>> GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }
        public void Add(KeyValuePair<TKey,TVal> item)
        {
            dictionary.Add(item.Key,item.Value);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
