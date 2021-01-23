    class ItemListViewModel<T> : INotifyPropertyChanged where T : class
    {
        private T _item;
        private ObservableCollection<T> _items;
    
        public ItemListViewModel()
        {
            _items = new ObservableCollection<T>();
            _item = null;
        }
    
        public void SetItems(IEnumerable<T> items)
        {
            Items = new ObservableCollection<T>(items);
            SelectedItem = null; 
        }
    
        public ObservableCollection<T> Items
        {
            get { return _items; }
            private set
            {
                _items = value;
                RaisePropertyChanged("Items");
            }
        }
    
        public T SelectedItem
        {
            get { return _item; }
            set
            {
                _item = value;
                RaisePropertyChanged("SelectedItem");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
