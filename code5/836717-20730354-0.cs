    public class ThreadSafeObservableCollection<T> : ObservableCollection<T>
    {
        private readonly object _lock = new object();
    
        public ThreadSafeObservableCollection()
        {
            BindingOperations.CollectionRegistering += CollectionRegistering;
        }
    
        protected override void InsertItem(int index, T item)
        {
            lock (_lock)
            {
                base.InsertItem(index, item);
            }
        }
    
        private void CollectionRegistering(object sender, CollectionRegisteringEventArgs e)
        {
            if (e.Collection == this)
                BindingOperations.EnableCollectionSynchronization(this, _lock);
        }
    }
