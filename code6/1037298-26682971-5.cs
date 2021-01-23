    [Serializable]
    [JsonObject]
    public class ListContainer<T> : IList<T> 
    {
        [JsonIgnore]
        readonly List<T> _list = new List<T>();
        [JsonProperty("List")]
        private IList<T> SerializableList
        {
            get
            {
                var proxy = new ObservableCollection<T>(_list);
                proxy.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(proxy_CollectionChanged);
                return proxy;
            }
            set
            {
                _list.Clear();
                _list.AddRange(value);
            }
        }
        void proxy_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems.Cast<T>())
                    Add(item);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.NewItems.Cast<T>())
                    Remove(item);
            }
            else
            {
                Debug.Assert(false);
                throw new NotImplementedException();
            }
        }
        [JsonIgnore]
        public int Count
        {
            get { return _list.Count; }
        }
        [JsonIgnore]
        public bool IsReadOnly
        {
            get { return ((IList<T>)_list).IsReadOnly; }
        }
        // Everything beyond here is boilerplate.
        #region IList<T> Members
        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }
        public T this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                _list[index] = value;
            }
        }
        #endregion
        #region ICollection<T> Members
        public void Add(T item)
        {
            _list.Add(item);
        }
        public void Clear()
        {
            _list.Clear();
        }
        public bool Contains(T item)
        {
            return _list.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }
        public bool Remove(T item)
        {
            return _list.Remove(item);
        }
        #endregion
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
