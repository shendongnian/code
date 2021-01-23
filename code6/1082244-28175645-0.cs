    public sealed class ObservableNotifiableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        public event ItemPropertyChangedEventHandler ItemPropertyChanged;
        public event EventHandler CollectionCleared;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            base.OnCollectionChanged(args);
            if (args.NewItems != null)
            {
                foreach (INotifyPropertyChanged item in args.NewItems)
                {
                    item.PropertyChanged += this.OnItemPropertyChanged;
                }
            }
            if (args.OldItems != null)
            {
                foreach (INotifyPropertyChanged item in args.OldItems)
                {
                    item.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
        }
        protected override void ClearItems()
        {
            foreach (INotifyPropertyChanged item in this.Items)
            {
                item.PropertyChanged -= this.OnItemPropertyChanged;
            }
            base.ClearItems();
            this.OnCollectionCleared();
        }
        private void OnCollectionCleared()
        {
            EventHandler eventHandler = this.CollectionCleared;
            if (eventHandler != null)
            {
                eventHandler(this, EventArgs.Empty);
            }
        }
        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            ItemPropertyChangedEventHandler eventHandler = this.ItemPropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new ItemPropertyChangedEventArgs(sender, args.PropertyName));
            }
        }
    }
