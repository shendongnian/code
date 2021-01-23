    public class NameValueCollectionDictionaryWrapper: IDictionary<string, string []>
    {
        readonly NameValueCollection collection;
        public NameValueCollectionDictionaryWrapper()
            : this(new NameValueCollection())
        {
        }
        public NameValueCollectionDictionaryWrapper(NameValueCollection collection)
        {
            this.collection = collection;
        }
        // Method instead of a property to guarantee that nobody tries to serialize it.
        public NameValueCollection GetCollection()
        {
            return collection;
        }
        #region IDictionary<string,string[]> Members
        public void Add(string key, string[] value)
        {
            if (collection.GetValues(key) != null)
                throw new ArgumentException("Duplicate key " + key);
            foreach (var str in value)
                collection.Add(key, str);
        }
        public bool ContainsKey(string key)
        {
            return collection.GetValues(key) != null;
        }
        public ICollection<string> Keys
        {
            get {
                return collection.AllKeys;
            }
        }
        public bool Remove(string key)
        {
            bool found = ContainsKey(key);
            if (found)
                collection.Remove(key);
            return found;
        }
        public bool TryGetValue(string key, out string[] value)
        {
            value = collection.GetValues(key);
            return value != null;
        }
        public ICollection<string[]> Values
        {
            get {
                return Enumerable.Range(0, collection.Count).Select(i => collection.GetValues(i)).ToArray();
            }
        }
        public string[] this[string key]
        {
            get
            {
                var value = collection.GetValues(key);
                if (value == null)
                    throw new KeyNotFoundException();
                return value;
            }
            set
            {
                Remove(key);
                Add(key, value);
            }
        }
        #endregion
        #region ICollection<KeyValuePair<string,string[]>> Members
        public void Add(KeyValuePair<string, string[]> item)
        {
            Add(item.Key, item.Value);
        }
        public void Clear()
        {
            collection.Clear();
        }
        public bool Contains(KeyValuePair<string, string[]> item)
        {
            string [] value;
            if (!TryGetValue(item.Key, out value))
                return false;
            return EqualityComparer<string[]>.Default.Equals(item.Value, value); // Consistent with Dictionary<TKey, TValue>
        }
        public void CopyTo(KeyValuePair<string, string[]>[] array, int arrayIndex)
        {
            foreach (var item in this)
                array[arrayIndex++] = item;
        }
        public int Count
        {
            get { return collection.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(KeyValuePair<string, string[]> item)
        {
            if (Contains(item))
                return Remove(item.Key);
            return false;
        }
        #endregion
        #region IEnumerable<KeyValuePair<string,string[]>> Members
        public IEnumerator<KeyValuePair<string, string[]>> GetEnumerator()
        {
            foreach (string key in collection)
            {
                yield return new KeyValuePair<string, string[]>(key, collection.GetValues(key)); 
            }
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
