    public class NameValueCollectionDictionaryAdapter<TNameValueCollection> : IDictionary<string, string[]>
        where TNameValueCollection : NameValueCollection, new()
    {
        readonly TNameValueCollection collection;
        public NameValueCollectionDictionaryAdapter() : this(new TNameValueCollection()) { }
        public NameValueCollectionDictionaryAdapter(TNameValueCollection collection)
        {
            this.collection = collection;
        }
        // Method instead of a property to guarantee that nobody tries to serialize it.
        public TNameValueCollection GetCollection() { return collection; }
        #region IDictionary<string,string[]> Members
        public void Add(string key, string[] value)
        {
            if (collection.GetValues(key) != null)
                throw new ArgumentException("Duplicate key " + key);
            if (value == null)
                collection.Add(key, null);
            else
                foreach (var str in value)
                    collection.Add(key, str);
        }
        public bool ContainsKey(string key) { return collection.GetValues(key) != null; }
        public ICollection<string> Keys { get { return collection.AllKeys; } }
        public bool Remove(string key)
        {
            bool found = ContainsKey(key);
            if (found)
                collection.Remove(key);
            return found;
        }
        public bool TryGetValue(string key, out string[] value)
        {
            return (value = collection.GetValues(key)) != null;
        }
        public ICollection<string[]> Values
        {
            get
            {
                return new ReadOnlyCollectionAdapter<KeyValuePair<string, string[]>, string[]>(this, p => p.Value);
            }
        }
        public string[] this[string key]
        {
            get
            {
                var value = collection.GetValues(key);
                if (value == null)
                    throw new KeyNotFoundException(key);
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
        public void Add(KeyValuePair<string, string[]> item) { Add(item.Key, item.Value); }
        public void Clear() { collection.Clear(); }
        public bool Contains(KeyValuePair<string, string[]> item)
        {
            string[] value;
            if (!TryGetValue(item.Key, out value))
                return false;
            return EqualityComparer<string[]>.Default.Equals(item.Value, value); // Consistent with Dictionary<TKey, TValue>
        }
        public void CopyTo(KeyValuePair<string, string[]>[] array, int arrayIndex)
        {
            foreach (var item in this)
                array[arrayIndex++] = item;
        }
        public int Count { get { return collection.Count; } }
        public bool IsReadOnly { get { return false; } }
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
                yield return new KeyValuePair<string, string[]>(key, collection.GetValues(key));
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
        #endregion
    }
    public static class NameValueCollectionExtensions
    {
        public static NameValueCollectionDictionaryAdapter<TNameValueCollection> ToDictionaryAdapter<TNameValueCollection>(this TNameValueCollection collection)
            where TNameValueCollection : NameValueCollection, new()
        {
            if (collection == null)
                throw new ArgumentNullException();
            return new NameValueCollectionDictionaryAdapter<TNameValueCollection>(collection);
        }
    }
    public class ReadOnlyCollectionAdapter<TIn, TOut> : CollectionAdapterBase<TIn, TOut, ICollection<TIn>>
    {
        public ReadOnlyCollectionAdapter(ICollection<TIn> collection, Func<TIn, TOut> toOuter)
            : base(() => collection, toOuter)
        {
        }
        public override void Add(TOut item) { throw new NotImplementedException(); }
        public override void Clear() { throw new NotImplementedException(); }
        public override bool IsReadOnly { get { return true; } }
        public override bool Remove(TOut item) { throw new NotImplementedException(); }
    }
    public abstract class CollectionAdapterBase<TIn, TOut, TCollection> : ICollection<TOut> 
        where TCollection : ICollection<TIn>
    {
        readonly Func<TCollection> getCollection;
        readonly Func<TIn, TOut> toOuter;
        public CollectionAdapterBase(Func<TCollection> getCollection, Func<TIn, TOut> toOuter)
        {
            if (getCollection == null || toOuter == null)
                throw new ArgumentNullException();
            this.getCollection = getCollection;
            this.toOuter = toOuter;
        }
        protected TCollection Collection { get { return getCollection(); } }
        protected TOut ToOuter(TIn inner) { return toOuter(inner); }
        #region ICollection<TOut> Members
        public abstract void Add(TOut item);
        public abstract void Clear();
        public virtual bool Contains(TOut item)
        {
            var comparer = EqualityComparer<TOut>.Default;
            foreach (var member in Collection)
                if (comparer.Equals(item, ToOuter(member)))
                    return true;
            return false;
        }
        public void CopyTo(TOut[] array, int arrayIndex)
        {
            foreach (var item in this)
                array[arrayIndex++] = item;
        }
        public int Count { get { return Collection.Count; } }
        public abstract bool IsReadOnly { get; }
        public abstract bool Remove(TOut item);
        #endregion
        #region IEnumerable<TOut> Members
        public IEnumerator<TOut> GetEnumerator()
        {
            foreach (var item in Collection)
                yield return ToOuter(item);
        }
        #endregion
        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        #endregion
    }
