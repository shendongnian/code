    public class CustomCollection<TKey, TValue> : IDictionary<TKey, TValue>
    {
        protected List<KeyValuePair<TKey, TValue>> List { get; set; }
        protected SortedList<TKey, TValue> SortedList { get; set; }
        // Two comparers needed: an EqualityComparer and a Comparer to sort
        // We could simply use the Comparer and compare the result to 0
        // instead of using an EqualityComparer and a Comparer
        protected readonly EqualityComparer<TKey> EqualityComparer = EqualityComparer<TKey>.Default;
        protected readonly Comparer<TKey> Comparer = Comparer<TKey>.Default;
        public int MaxCapacityList { get; protected set; }
        public CustomCollection(int maxCapacityList = 10)
        {
            MaxCapacityList = maxCapacityList;
            if (maxCapacityList > 0)
            {
                List = new List<KeyValuePair<TKey, TValue>>();
            }
            else
            {
                SortedList = new SortedList<TKey, TValue>();
            }
        }
        public bool IsUsingList
        {
            get
            {
                return List != null;
            }
        }
        public void Add(TKey key, TValue value)
        {
            if (IsUsingList)
            {
                if (key == null)
                {
                    throw new ArgumentNullException();
                }
                if (List.Any(x => EqualityComparer.Equals(x.Key, key)))
                {
                    throw new ArgumentException();
                }
            }
            if (IsUsingList && List.Count < MaxCapacityList)
            {
                List.Add(new KeyValuePair<TKey, TValue>(key, value));
                // Only place we need to sort. Only "real" Add method
                List.Sort((x, y) => Comparer.Compare(x.Key, y.Key));
            }
            else
            {
                if (IsUsingList && List.Count == MaxCapacityList)
                {
                    SortedList = new SortedList<TKey, TValue>();
                    foreach (var kv in List)
                    {
                        SortedList.Add(kv.Key, kv.Value);
                    }
                    List = null;
                }
                SortedList.Add(key, value);
            }
        }
        public bool ContainsKey(TKey key)
        {
            if (IsUsingList)
            {
                if (key == null)
                {
                    throw new ArgumentNullException();
                }
                if (List.Any(x => EqualityComparer.Equals(x.Key, key)))
                {
                    return true;
                }
                return false;
            }
            return SortedList.ContainsKey(key);
        }
        public ICollection<TKey> Keys
        {
            get
            {
                if (IsUsingList)
                {
                    return List.ConvertAll(x => x.Key);
                }
                return SortedList.Keys;
            }
        }
        public bool Remove(TKey key)
        {
            if (IsUsingList)
            {
                if (key == null)
                {
                    throw new ArgumentNullException();
                }
                for (int ix = 0; ix < List.Count; ix++)
                {
                    if (EqualityComparer.Equals(List[ix].Key, key))
                    {
                        List.RemoveAt(ix);
                        return true;
                    }
                }
                return false;
            }
            bool result = SortedList.Remove(key);
            if (result && SortedList.Count == MaxCapacityList && MaxCapacityList > 0)
            {
                List = new List<KeyValuePair<TKey, TValue>>();
                foreach (var kv in SortedList)
                {
                    List.Add(new KeyValuePair<TKey, TValue>(kv.Key, kv.Value));
                }
                SortedList = null;
            }
            return result;
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            if (IsUsingList)
            {
                if (key == null)
                {
                    throw new ArgumentNullException();
                }
                for (int i = 0; i < List.Count; i++)
                {
                    if (EqualityComparer.Equals(List[i].Key, key))
                    {
                        value = List[i].Value;
                        return true;
                    }
                }
                value = default(TValue);
                return false;
            }
            return SortedList.TryGetValue(key, out value);
        }
        public ICollection<TValue> Values
        {
            get
            {
                if (IsUsingList)
                {
                    return List.ConvertAll(x => x.Value);
                }
                return SortedList.Values;
            }
        }
        public TValue this[TKey key]
        {
            get
            {
                if (IsUsingList)
                {
                    if (key == null)
                    {
                        throw new ArgumentNullException();
                    }
                    for (int ix = 0; ix < List.Count; ix++)
                    {
                        if (EqualityComparer.Equals(List[ix].Key, key))
                        {
                            return List[ix].Value;
                        }
                    }
                    throw new KeyNotFoundException();
                }
                return SortedList[key];
            }
            set
            {
                if (IsUsingList)
                {
                    if (key == null)
                    {
                        throw new ArgumentNullException();
                    }
                    for (int ix = 0; ix < List.Count; ix++)
                    {
                        if (EqualityComparer.Equals(List[ix].Key, key))
                        {
                            List[ix] = new KeyValuePair<TKey, TValue>(key, value);
                            return;
                        }
                    }
                    Add(key, value);
                    return;
                }
                SortedList[key] = value;
            }
        }
        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }
        public void Clear()
        {
            if (IsUsingList)
            {
                List.Clear();
            }
            else
            {
                if (MaxCapacityList > 0)
                {
                    List = new List<KeyValuePair<TKey, TValue>>();
                    SortedList = null;
                }
                else
                {
                    SortedList.Clear();
                }
            }
        }
        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            if (IsUsingList)
            {
                if (item.Key == null)
                {
                    throw new ArgumentNullException();
                }
                return List.Any(x => EqualityComparer.Equals(x.Key, item.Key));
            }
            return ((ICollection<KeyValuePair<TKey, TValue>>)SortedList).Contains(item);
        }
        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (IsUsingList)
            {
                List.CopyTo(array, arrayIndex);
                return;
            }
            ((ICollection<KeyValuePair<TKey, TValue>>)SortedList).CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return IsUsingList ? List.Count : SortedList.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            if (IsUsingList)
            {
                if (item.Key == null)
                {
                    throw new ArgumentNullException();
                }
                for (int ix = 0; ix < List.Count; ix++)
                {
                    if (EqualityComparer.Equals(List[ix].Key, item.Key))
                    {
                        var comparer2 = EqualityComparer<TValue>.Default;
                        if (comparer2.Equals(List[ix].Value, item.Value))
                        {
                            List.RemoveAt(ix);
                            return true;
                        }
                        return false;
                    }
                }
                return false;
            }
            bool result = ((ICollection<KeyValuePair<TKey, TValue>>)SortedList).Remove(item);
            if (result && SortedList.Count == MaxCapacityList && MaxCapacityList > 0)
            {
                List = new List<KeyValuePair<TKey, TValue>>();
                foreach (var kv in SortedList)
                {
                    List.Add(new KeyValuePair<TKey, TValue>(kv.Key, kv.Value));
                }
                SortedList = null;
            }
            return result;
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return IsUsingList ? List.GetEnumerator() : SortedList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            // Chained to the other GetEnumerator()
            return GetEnumerator();
        }
    }
