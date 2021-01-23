    public class NotificationCollection : ObservableCollection<Notification>
    {
        public NotificationCollection() : base() {}
    
        public NotificationCollection(IEnumerable<Notification> items)
            : base(items) {}
        protected override void OnCollectionChanged(
            NotifyCollectionChangedEventArgs e)
        {
            // YOUR CODE HERE
            base.OnCollectionChanged(e);
        }
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            // YOUR CODE HERE
            base.OnPropertyChanged(e);
        }
    }
