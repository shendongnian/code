    object someObject = ...
    bool itsAnObservableCollection = IsObservableCollection(someObject);
    
    if (itsAnObservableCollection) {
        IEnumerable elements = someObject as IEnumerable;
        // and try to reason about the elements in this manner
        foreach (var element in elements) { ... }
        INotifyCollectionChanged asCC = someObject as INotifyCollectionChanged;
        INotifyPropertyChanged asPC = someObject as INotifyPropertyChanged;
        // and try to let yourself receive notifications in this manner
        asCC.CollectionChanged += (sender, e) => {
            var newItems = e.NewItems;
            var oldItems = e.OldItems; 
            ...
        };     
        asPC.PropertyChanged += (sender, e) => {
            var propertyName = e.PropertyName;
            ...
        };   
    }
