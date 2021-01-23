    public class R
    {
        protected string name;
        protected System.Collections.ObjectModel.ObservableCollection<S> ListOfObjectS { get; private set; }
        public R()
        {
            ListOfObjectS = new ObservableCollection<S>();
            ListOfObjectS.CollectionChanged += listOfObjectS_CollectionChanged;
        }
        void listOfObjectS_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var newItems = (e.NewItems ?? new INotifyPropertyChanged[0]).OfType<INotifyPropertyChanged>();
                foreach (var item in newItems)
                    item.PropertyChanged += item_PropertyChanged;
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                var oldItems = (e.OldItems ?? new INotifyPropertyChanged[0]).OfType<INotifyPropertyChanged>();
                foreach (var item in oldItems)
                    item.PropertyChanged += item_PropertyChanged;
            }
        }
        void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.StartsWith("ObjectA."))
            {
                // Refresh any dependent views, forms, controls, whatever...
            }
        }
    }
