        ObservableCollection<object> _bindSelectedItems;
        public ObservableCollection<object> BindSelectedItems
        {
            get { return _bindSelectedItems; }
            set
            {
                _bindSelectedItems = value;
                _bindSelectedItems.CollectionChanged += _bindSelectedItems_CollectionChanged;
                RaisePropertyChanged("BindSelectedItems");
            }
        }
        void _bindSelectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ObservableCollection<object> items = sender as ObservableCollection<object>;
        }
