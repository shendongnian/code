    public class ObservableWrapper<T> : 
        ICollection<T>, IList<T>, INotifyCollectionChanged
    {
        private ObservableCollection<T> other;
        private bool changing = false;
        public ObservableWrapper(ObservableCollection<T> wrapped)
        {
            other = wrapped;
            other.CollectionChanged += (sender, args) =>
            {
                var handler = CollectionChanged;
                if (handler != null && !changing)
                    handler(sender, args);
            };
        }
        public void Add(T item)
        {
            changing = true;
            other.Add(item);
            changing = false;
        }
        public void Clear()
        {
            changing = true;
            other.Clear();
            changing = false;
        }
        public bool Contains(T item)
        {
            return other.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            other.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return other.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(T item)
        {
            changing = true;
            bool result = other.Remove(item);
            changing = false;
            return result;
        }
        public int IndexOf(T item)
        {
            return IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            changing = true;
            other.Insert(index, item);
            changing = false;
        }
        public void RemoveAt(int index)
        {
            changing = true;
            other.RemoveAt(index);
            changing = false;
        }
        public T this[int index]
        {
            get
            {
                return other[index];
            }
            set
            {
                changing = true;
                other[index] = value;
                changing = false;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return other.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return other.GetEnumerator();
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
