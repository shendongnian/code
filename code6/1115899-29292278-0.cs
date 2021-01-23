    private class Wrapper : INotifyCollectionChanged
    {
        private readonly ObservableCollection<string> _internal 
                                     = new ObservableCollection<string>();
        public Wrapper()
        {
            _internal.CollectionChanged += OnInternalChanged;
        }
        public void Add(string s)
        {
            _internal.Add(s);
        }
        private void OnInternalChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var toRaise = CollectionChanged;
            if (toRaise != null)
                toRaise(this, e);
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
