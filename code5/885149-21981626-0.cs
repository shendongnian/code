    class MyObservableCollection<T> : ObservableCollection<T>
        where T : INotifyPropertyChanged
    {
        private void Initialize()
        {
            // initial PropertyChanged subscription
            foreach (var item in Items)
            {
                SubscribeItemPropertyChanged(item);
            }
        }
        private void SubscribeItemPropertyChanged(object item)
        {
            ((INotifyPropertyChanged)item).PropertyChanged += HandleItemPropertyChanged;
        }
        private void UnSubscribeItemPropertyChanged(object item)
        {
            ((INotifyPropertyChanged)item).PropertyChanged -= HandleItemPropertyChanged;
        }
        protected virtual void HandleItemPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            var handler = ItemPropertyChanged;
            if (handler != null)
            {
                handler(sender, args);
            }
        }
        protected override void ClearItems()
        {
            // we should unsubscribe from INotifyPropertyChanged.PropertyChanged event for each item
            Items.ToList().ForEach(item => Remove(item));
        }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            // subscribe for new items property changing;
            // un-subscribe for old items property changing
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    SubscribeItemPropertyChanged(e.NewItems[0]);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    UnSubscribeItemPropertyChanged(e.OldItems[0]);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    SubscribeItemPropertyChanged(e.NewItems[0]);
                    UnSubscribeItemPropertyChanged(e.OldItems[0]);
                    break;
            }
        }
        public MyObservableCollection()
            : base()
        {
        }
        public MyObservableCollection(IEnumerable<T> collection)
            : base(collection)
        {
            Initialize();
        }
        public MyObservableCollection(List<T> list)
            : base(list)
        {
            Initialize();
        }
        public EventHandler<PropertyChangedEventArgs> ItemPropertyChanged;
    }
