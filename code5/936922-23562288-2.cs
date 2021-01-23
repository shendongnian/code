    public class LazyCollection<T> : IList<T>, IList, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private const int LOAD_THRESHOLD = 3;
        private ObservableCollection<T> _innerCollection;
        public LazyCollection(Func<int, IEnumerable<T>> fetch)
            : this(fetch, null)
        { }
        public LazyCollection(Func<int, IEnumerable<T>> fetch, IEnumerable<T> items)
        {
            _fetch = fetch;
            _innerCollection = new ObservableCollection<T>(items ?? new T[0]);
            this.AttachEvents();
            this.HasMoreItems = true;
        }
        private void AttachEvents()
        {
            _innerCollection.CollectionChanged += (s, e) => OnCollectionChanged(e);
            ((INotifyPropertyChanged)_innerCollection).PropertyChanged += (s, e) => OnPropertyChanged(e);
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, e);
        }
        #endregion
        #region INotifyCollectionChanged
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (this.CollectionChanged != null)
                this.CollectionChanged(this, e);
        }
        #endregion
        #region IList<T>
        public int IndexOf(T item)
        {
            return _innerCollection.IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            _innerCollection.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            _innerCollection.RemoveAt(index);
        }
        public T this[int index]
        {
            get
            {
                Debug.WriteLine("LazyCollection - Reading item {0}", index);
                return _innerCollection[index];
            }
            set { _innerCollection[index] = value; }
        }
        public void Add(T item)
        {
            _innerCollection.Add(item);
        }
        public void Clear()
        {
            _innerCollection.Clear();
        }
        public bool Contains(T item)
        {
            return _innerCollection.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            _innerCollection.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return _innerCollection.Count; }
        }
        public bool IsReadOnly
        {
            get { return ((IList<T>)_innerCollection).IsReadOnly; }
        }
        public bool Remove(T item)
        {
            return _innerCollection.Remove(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            Debug.WriteLine("LazyCollection - GetEnumerator");
            return _innerCollection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            Debug.WriteLine("LazyCollection - GetEnumerator explicit");
            return ((IEnumerable)_innerCollection).GetEnumerator();
        }
        #endregion
        #region IList
        int IList.Add(object value)
        {
            return ((IList)_innerCollection).Add(value);
        }
        bool IList.Contains(object value)
        {
            return ((IList)_innerCollection).Contains(value);
        }
        int IList.IndexOf(object value)
        {
            return ((IList)_innerCollection).IndexOf(value);
        }
        void IList.Insert(int index, object value)
        {
            ((IList)_innerCollection).Insert(index, value);
        }
        bool IList.IsFixedSize
        {
            get { return ((IList)_innerCollection).IsFixedSize; }
        }
        bool IList.IsReadOnly
        {
            get { return ((IList)_innerCollection).IsReadOnly; }
        }
        void IList.Remove(object value)
        {
            ((IList)_innerCollection).Remove(value);
        }
        object IList.this[int index]
        {
            get
            {
                if (index > this.Count - LOAD_THRESHOLD)
                {
                    this.TryLoadMoreItems();
                }
                Debug.WriteLine("LazyCollection - Reading item {0} IList", index);
                return ((IList)_innerCollection)[index];
            }
            set { ((IList)_innerCollection)[index] = value; }
        }
        void ICollection.CopyTo(Array array, int index)
        {
            ((IList)_innerCollection).CopyTo(array, index);
        }
        bool ICollection.IsSynchronized
        {
            get { return ((IList)_innerCollection).IsSynchronized; }
        }
        object ICollection.SyncRoot
        {
            get { return ((IList)_innerCollection).SyncRoot; }
        }
        #endregion
        public T[] GetLoadedItems()
        {
            return _innerCollection.ToArray();
        }
        public void ResetLoadedItems(IEnumerable<T> list)
        {
            _innerCollection.Clear();
            foreach (var i in list)
                _innerCollection.Add(i);
            this.HasMoreItems = true;
        }
        public bool HasMoreItems { get; set; }
        private bool _isLoading = false;
        private Func<int, IEnumerable<T>> _fetch;
        private async Task TryLoadMoreItems()
        {
            if (_isLoading || !this.HasMoreItems)
                return;
            try
            {
                _isLoading = true;
                Debug.WriteLine("LazyCollection - Loading more items skip {0}", this.Count);
                List<T> items = _fetch != null ? (_fetch(Count)).ToList() : new List<T>();
                if (items.Count == 0)
                {
                    Debug.WriteLine("LazyCollection - No items returned, Loading disabled", this.Count);
                    this.HasMoreItems = false;
                }
                items.ForEach(x => _innerCollection.Add(x));
                Debug.WriteLine("LazyCollection - Items added. Total count: {0}", this.Count);
            }
            finally
            {
                _isLoading = false;
            }
        }
    }
