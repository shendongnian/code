    public class SmartCollection<T> : ObservableCollection<T>
    {
        public SmartCollection()
            : base()
        {
            _suspendCollectionChangeNotification = false;
        }
        bool _suspendCollectionChangeNotification;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_suspendCollectionChangeNotification)
            {
                base.OnCollectionChanged(e);
            }
        }
        public void SuspendCollectionChangeNotification()
        {
            _suspendCollectionChangeNotification = true;
        }
        public void ResumeCollectionChangeNotification()
        {
            _suspendCollectionChangeNotification = false;
        }
        public void AddRange(IEnumerable<T> items)
        {
            this.SuspendCollectionChangeNotification();
            int index = base.Count;
            try
            {
                foreach (var i in items)
                {
                    base.InsertItem(base.Count, i);
                }
            }
            finally
            {
                this.ResumeCollectionChangeNotification();
                var arg = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
                this.OnCollectionChanged(arg);
            }
        }
    }
