    void ChangeHandler(object sender, NotifyCollectionChangedEventArgs e ) {
        switch (e.Action) {
            case NotifyCollectionChangedAction.Add:
                // One or more items were added to the collection.
                break;
            case NotifyCollectionChangedAction.Move:
                // One or more items were moved within the collection.
                break;
            case NotifyCollectionChangedAction.Remove:
                // One or more items were removed from the collection.
                break;
            case NotifyCollectionChangedAction.Replace:
                // One or more items were replaced in the collection.
                break;
            case NotifyCollectionChangedAction.Reset:
                // The content of the collection changed dramatically.
                break;
        }
    }
    void test() {
        var myList = ObservableCollection<int>();
        myList.CollectionChanged += ChangeHandler;
    }
