    ObservableCollection<DataItem> baseCollection = new ObservableCollection<DataItem>();
    
    // adding/removing items
    ObservableCollection<DataItem> serviceCollection = new ObservableCollection<DataItem>();
    
    // adding/removing items
    baseCollection.Clear();
    // replacing old collection with the new one
    baseCollection = serviceCollection;
