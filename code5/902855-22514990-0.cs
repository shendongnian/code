    public class MyDictionary<TKey, TItem> : IDictionary<TKey, TItem>
        where TKey : IComparable<TKey>
        where TItem : IEquatable<TItem>
    {
        private readonly List<TKey> keys;
        private readonly List<TItem> items;
        private readonly ReadOnlyCollection<TKey> roKeys;
        private readonly ReadOnlyCollection<TItem> roItems;
        public MyDictionary()
        {
            keys = new List<TKey>();
            items = new List<TItem>();
            roKeys = new ReadOnlyCollection<TKey>(keys);
            roItems = new ReadOnlyCollection<TItem>(items);
        }
        public MyDictionary(int capacity)
        {
            keys = new List<TKey>(capacity);
            items = new List<TItem>(capacity);
            roKeys = new ReadOnlyCollection<TKey>(keys);
            roItems = new ReadOnlyCollection<TItem>(items);
        }
        public int BinarySearch(TKey key)
        {
            return keys.BinarySearch(key);
        }
        public bool ContainsKey(TKey key)
        {
            return BinarySearch(key) >= 0;
        }
        public void Add(TKey key, TItem item)
        {
            int index = BinarySearch(key);
            if (index >= 0)
                throw new ArgumentException(String.Format("The key {0} already exists.", key), "key");
            index = ~index;
            keys.Insert(index, key);
            items.Insert(index, item);
        }
        public void Add(KeyValuePair<TKey, TItem> item)
        {
            Add(item.Key, item.Value);
        }
        public bool Remove(TKey key)
        {
            int index = BinarySearch(key);
            if (index < 0)
                return false;
            keys.RemoveAt(index);
            items.RemoveAt(index);
            return true;
        }
        public bool Remove(KeyValuePair<TKey, TItem> item)
        {
            int index = BinarySearch(item.Key);
            if (index < 0)
                return false;
            index = ~index;
            keys.RemoveAt(index);
            items.RemoveAt(index);
            return true;
        }
        public bool Contains(KeyValuePair<TKey, TItem> item)
        {
            int index = BinarySearch(item.Key);
            if (index < 0)
                return false;
            index = ~index;
            return items[index].Equals(item.Value);
        }
        public bool TryGetValue(TKey key, out TItem value)
        {
            int index = BinarySearch(key);
            if (index < 0)
            {
                value = default(TItem);
                return false;
            }
            value = items[index];
            return true;
        }
        public TItem this[TKey key]
        {
            get
            {
                int index = BinarySearch(key);
                if (index < 0)
                    throw new ArgumentException(String.Format("The key {0} not found.", key), "key");
                return items[index];
            }
            set
            {
                int index = BinarySearch(key);
                if (index < 0)
                    throw new ArgumentException(String.Format("The key {0} not found.", key), "key");
                items[index] = value;
            }
        }
        public ICollection<TKey> Keys
        {
            get { return roKeys; }
        }
        public ICollection<TItem> Values
        {
            get { return roItems; }
        }
        public IEnumerator<KeyValuePair<TKey, TItem>> GetEnumerator()
        {
            return keys.Select((t, i) => new KeyValuePair<TKey, TItem>(t, items[i])).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Clear()
        {
            keys.Clear();
            items.Clear();
        }
        public void CopyTo(KeyValuePair<TKey, TItem>[] array, int arrayIndex)
        {
            Array.Copy(keys.Select((t, i) => new KeyValuePair<TKey, TItem>(t, items[i])).ToArray(), 0, array, arrayIndex, Count);
        }
        public int Count
        {
            get { return keys.Count; } 
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public int GetSmallerOrEqualIndex(TKey key)
        {
            int index = BinarySearch(key);
            if (index >= 0)
                return index;
            index = ~index;
            return index - 1;
        }
        public int GetGreaterOrEqualIndex(TKey key)
        {
            int index = BinarySearch(key);
            if (index >= 0)
                return index;
            index = ~index;
            return index;
        }
        public KeyValuePair<TKey, TItem> GetItem(int index)
        {
            return new KeyValuePair<TKey, TItem>(keys[index], items[index]);
        }
    }
