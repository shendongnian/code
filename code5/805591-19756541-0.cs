    public class PlusOneObservableCollection<T> : IList<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private ObservableCollection<T> innerCollection;
        public PlusOneObservableCollection()
        {
            this.innerCollection = new ObservableCollection<T>();
            this.innerCollection.CollectionChanged += InnerCollection_CollectionChanged;
        }
        public PlusOneObservableCollection(IEnumerable<T> collection)
        {
            this.innerCollection = new ObservableCollection<T>(collection);
            this.innerCollection.CollectionChanged += InnerCollection_CollectionChanged;
        }
        private void InnerCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler handler = this.CollectionChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public int IndexOf(T item)
        {
            return this.innerCollection.IndexOf(item);
        }
        public void Insert(int index, T item)
        {
            this.innerCollection.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            this.innerCollection.RemoveAt(index);
        }
        public T this[int index]
        {
            get
            {
                //Here is where the actual change takes place
                return this.innerCollection[index + 1];
            }
            set
            {
                this.innerCollection[index] = value;
            }
        }
        public void Add(T item)
        {
            this.innerCollection.Add(item);
        }
        public void Clear()
        {
            this.innerCollection.Clear();
        }
        public bool Contains(T item)
        {
            return this.innerCollection.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.innerCollection.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return this.innerCollection.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(T item)
        {
            return this.innerCollection.Remove(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.innerCollection.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.innerCollection.GetEnumerator();
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
    }
