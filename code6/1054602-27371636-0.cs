    private CollectionViewSource _sortedCollection = new CollectionViewSource();
    public CollectionViewSource SortedCollection {
        get {
            _sortedCollection.Source = this.Items; // Set source to our original ObservableCollection
            return _sortedCollection;
        }
        set {
            if (value != _sortedCollection) {
                _sortedCollection = value;
                RaiseNotifyPropertyChanged("SortedCollection"); // MVVMLight ObservableObject
            }
        }
    }
