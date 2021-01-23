    public class ObservableList<T> : IList<T>, IDisposable
        where T : INotifyPropertyChanged
    {
        List<T> _innerList;
        bool _disposed;
        #region Notification
        public enum Action
        {
            Add,
            Remove,
            Replace,
            ItemPropertyChanged
        }
        public class ListOrItemChangedEventArgs : EventArgs
        {
            public ListOrItemChangedEventArgs(IList<T> oldItems, IList<T> newItems, int startingIndex, Action action, string propertyName)
            {
                StartingIndex = startingIndex;
                Action = action;
                OldItems = oldItems;
                NewItems = newItems;
            }
            public Action Action { get; private set; }
            public IList<T> OldItems { get; private set; }
            public IList<T> NewItems { get; private set; }
            public int StartingIndex { get; private set; }
            public string PropertyName { get; private set; }
        }
        public delegate void ListOrItemChangedEventHandler(ObservableList<T> sender, ListOrItemChangedEventArgs e);
        public event ListOrItemChangedEventHandler ListOrItemChanged;
        private void OnListOrItemChanged(IList<T> oldItems, IList<T> newItems, int startingIndex, Action action, string propertyName)
        {
            var eh = ListOrItemChanged;
            if (eh != null) {
                eh(this, new ListOrItemChangedEventArgs(oldItems, newItems, startingIndex, action, propertyName));
            }
        }
        void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            T item = (T)sender;
            OnListOrItemChanged(new List<T>(1) { item }, new List<T>(1) { item }, _innerList.IndexOf(item), Action.ItemPropertyChanged, e.PropertyName);
        }
        #endregion
        public ObservableList()
        {
            _innerList = new List<T>();
        }
        public ObservableList(int capacity)
        {
            _innerList = new List<T>(capacity);
        }
        public ObservableList(IEnumerable<T> items)
        {
            var coll = items as ICollection;
            if (coll == null) {
                _innerList = new List<T>();
            } else {
                _innerList = new List<T>(coll.Count);
            }
            foreach (T item in items) {
                _innerList.Add(item);
                if (item != null) {
                    item.PropertyChanged += Item_PropertyChanged;
                }
            }
        }
        public void AddRange(IEnumerable<T> items)
        {
            int startIndex = _innerList.Count;
            _innerList.AddRange(items);
            foreach (T item in items) {
                if (item != null) {
                    item.PropertyChanged += Item_PropertyChanged;
                }
            }
            OnListOrItemChanged(null, new List<T>(items), startIndex, Action.Add, null);
        }
        #region IList<T> Members
        public int IndexOf(T item)
        {
            return _innerList.IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            _innerList.Insert(index, item);
            if (item != null) {
                item.PropertyChanged += Item_PropertyChanged;
            }
            OnListOrItemChanged(null, new List<T>(1) { item }, index, Action.Add, null);
        }
        public void RemoveAt(int index)
        {
            T item = _innerList[index];
            _innerList.RemoveAt(index);
            if (item != null) {
                item.PropertyChanged -= Item_PropertyChanged;
            }
            OnListOrItemChanged(new List<T>(1) { item }, null, index, Action.Remove, null);
        }
        public T this[int index]
        {
            get { return _innerList[index]; }
            set
            {
                T oldItem = _innerList[index];
                if (oldItem != null) {
                    oldItem.PropertyChanged -= Item_PropertyChanged;
                }
                _innerList[index] = value;
                if (value != null) {
                    value.PropertyChanged += Item_PropertyChanged;
                }
                OnListOrItemChanged(new List<T>(1) { oldItem }, new List<T>(1) { value }, index, Action.Replace, null);
            }
        }
        #endregion
        #region ICollection<T> Members
        public void Add(T item)
        {
            int startIndex = _innerList.Count;
            _innerList.Add(item);
            if (item != null) {
                item.PropertyChanged += Item_PropertyChanged;
            }
            OnListOrItemChanged(null, new List<T>(1) { item }, startIndex, Action.Add, null);
        }
        public void Clear()
        {
            foreach (T item in _innerList) {
                if (item != null) {
                    item.PropertyChanged -= Item_PropertyChanged;
                }
            }
            var oldItems = _innerList;
            _innerList = new List<T>();
            OnListOrItemChanged(oldItems, null, 0, Action.Remove, null);
        }
        public bool Contains(T item)
        {
            return _innerList.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            _innerList.CopyTo(array, arrayIndex);
        }
        public int Count { get { return _innerList.Count; } }
        public bool IsReadOnly { get { return false; } }
        public bool Remove(T item)
        {
            int i = _innerList.IndexOf(item);
            if (i == -1) {
                return false;
            }
            item = _innerList[i]; // In case another instance is returned.
            if (item != null) {
                item.PropertyChanged -= Item_PropertyChanged;
            }
            _innerList.RemoveAt(i);
            OnListOrItemChanged(new List<T>(1) { item }, null, i, Action.Remove, null);
            return true;
        }
        #endregion
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }
        #endregion
        #region IDisposable Members
        /// <summary>
        /// Removes PropertyChanged event handlers from all the items.
        /// </summary>
        public void Dispose()
        {
            if (!_disposed) {
                _disposed = true;
                foreach (T item in _innerList) {
                    if (item != null) {
                        item.PropertyChanged -= Item_PropertyChanged;
                    }
                }
            }
        }
        #endregion
    }
