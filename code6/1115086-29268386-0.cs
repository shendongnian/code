    public class ElObservableCollection<T>: ObservableCollection<T> where T: INotifyPropertyChanged
    {
        public ElObservableCollection(): base()
        {
            CollectionChanged += OnCollectionChanged;
        }
        public virtual void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (var item in Items)
                {
                    item.PropertyChanged += OnItemChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (var item in Items)
                {
                    item.PropertyChanged -= OnItemChanged;
                }
            }
        }
        private void OnItemChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "TextProperty" && sender is StringDP)
            {
                StringDP sdp = sender as StringDP;
                if (sdp.Text == null)
                {
                    this.Remove((T) sender);
                }
            }
        }
        public ElObservableCollection(List<T> list)
            : base(list)
        {
            CollectionChanged += OnCollectionChanged;
        }
        public ElObservableCollection(IEnumerable<T> collection)
            : base(collection)
        {
            CollectionChanged += OnCollectionChanged;
        }
    }
