    private void OnItemsChanged(DependencyPropertyChangedEventArgs e)
    {
       var oldList = e.OldValue as ObservableCollection<ModelItem>;
       if (oldList != null) oldList.CollectionChanged -= MyCollectionChangedCallback;
       var newList = e.NewValue as ObservableCollection<ModelItem>;
       if (newList != null) newList.CollectionChanged += MyCollectionChangedCallback;
    }
