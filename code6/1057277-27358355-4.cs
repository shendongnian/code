    private void ChangeCollectionWithoutNotification(Action action)
    {
        myObservableColl.CollectionChanged -= MainWindowViewModel_CollectionChanged;
        action.Invoke();
        myObservableColl.CollectionChanged += MainWindowViewModel_CollectionChanged;
    }
