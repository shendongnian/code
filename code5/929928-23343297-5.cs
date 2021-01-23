    MyObservableCollection<T> : ObservableCollection<T>
    {
        private List<NotifyCollectionChangedEventHandler> changedHandlers = new List<NotifyCollectionChangedEventHandler>();
        public override event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add
            {
                changedHandlers.Add(value);
                base.CollectionChanged += value;
            }
            remove
            {
                changedHandlers.Remove(value);
                base.CollectionChanged -= value;
            }
         }
         public void RemoveCollectionChanged()
         {
             foreach (var handler in changedHandlers)
                 base.CollectionChanged -= handler;
             changedHandlers.Clear();
         }
    }
