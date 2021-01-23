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
        // The other properties of e tell you where in the list
        // the change took place, and what was affected.
    }
    void test() {
        var myList = ObservableCollection<int>();
        myList.CollectionChanged += ChangeHandler;
        myList.Add(4);
    }
