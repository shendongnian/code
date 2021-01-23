    /// <summary>
    /// ObservableCollection, supporting sorting of items
    /// which automatically refreshes when items notify property changes.
    /// </summary>
    /// <typeparam name="T">Item type</typeparam>
    public sealed class SortableObservableCollection<T> : INotifyCollectionChanged, ICollection<T>
    {
        private readonly IComparer<T> _comparer;
        private readonly List<T> _innerItems; 
        public SortableObservableCollection(IComparer<T> comparer)
        {
            _comparer = comparer;
            _innerItems = new List<T>();
        }
        public SortableObservableCollection(IEnumerable<T> collection, IComparer<T> comparer)
        {
            _comparer = comparer;
            _innerItems = new List<T>(collection);
        }
        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Sort();
        }
        public void Sort()
        {
            _innerItems.Sort(_comparer);
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private void RaiseAdd(T newItem)
        {
            if (CollectionChanged != null) CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newItem));
        }
        private void RaiseRemoved(T oldItem)
        {
            if (CollectionChanged != null) CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldItem));
        }
        private void RaiseReset()
        {
            if (CollectionChanged != null) CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _innerItems.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(T item)
        {
            // Subscribe to items change notification
            var inpc = item as INotifyPropertyChanged;
            if (inpc != null) inpc.PropertyChanged += Item_PropertyChanged;
            _innerItems.Add(item);
            Sort();
            RaiseAdd(item);
            RaiseReset();
        }
        public void Clear()
        {
            _innerItems.Clear();
            RaiseReset();
        }
        public bool Contains(T item)
        {
            return _innerItems.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            _innerItems.CopyTo(array, arrayIndex);
        }
        public bool Remove(T item)
        {
            // Unsubscribe from item's change notification
            var inpc = item as INotifyPropertyChanged;
            if (inpc != null) inpc.PropertyChanged -= Item_PropertyChanged;
            var removed = _innerItems.Remove(item);
            if (!removed) return false;
            
            Sort();
            RaiseRemoved(item);
            RaiseReset();
            
            return true;
        }
        public int Count { get { return _innerItems.Count; }}
        public bool IsReadOnly { get { return false; } }
    }
