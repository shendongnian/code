    private void ChangeCollectionWithoutNotification(Action action)
    {
        c.CollectionChanged -= MainWindowViewModel_CollectionChanged;
        action.Invoke();
        c.CollectionChanged += MainWindowViewModel_CollectionChanged;
    }
