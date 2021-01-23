    public class R
    {
        protected string name;
        protected System.Collections.ObjectModel.ObservableCollection<S> ListOfObjectS { get; private set; }
        public R()
        {
            // Use ObservableCollection instead.
            ListOfObjectS = new ObservableCollection<S>();
            // Subscribe to all changes to the collection.
            ListOfObjectS.CollectionChanged += listOfObjectS_CollectionChanged;
        }
        void listOfObjectS_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                // When items are removed, unsubscribe from property change notifications.
                var oldItems = (e.OldItems ?? new INotifyPropertyChanged[0]).OfType<INotifyPropertyChanged>();
                foreach (var item in oldItems)
                    item.PropertyChanged -= item_PropertyChanged;
            }
            // When item(s) are added, subscribe to property notifications.
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var newItems = (e.NewItems ?? new INotifyPropertyChanged[0]).OfType<INotifyPropertyChanged>();
                foreach (var item in newItems)
                    item.PropertyChanged += item_PropertyChanged;
            }
            // NOTE: I'm not handling NotifyCollectionChangedAction.Reset.
            // You'll want to look into when this event is raised and handle it
            // in a special fashion.
        }
        void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.StartsWith("ObjectA."))
            {
                // Refresh any dependent views, forms, controls, whatever...
            }
        }
    }
