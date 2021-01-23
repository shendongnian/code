    private static void OnItemsChangedProperty(DependencyObject obj, DependencyPropertyChangedEventArgs args)
    {
        MyControl ctrl = (MyControl)obj;
        INotifyCollectionChanged oldList = args.OldValue as INotifyCollectionChanged;
        INotifyCollectionChanged newList = args.NewValue as INotifyCollectionChanged;
        
        //If the old list implements the INotifyCollectionChanged interface, then unsubscribe to CollectionChanged events.
        if (oldList != null)
            oldList.CollectionChanged -= ctrl.OnItemsCollectionChanged;
        //If the new list implements the INotifyCollectionChanged interface, then subscribe to CollectionChanged events.
        if (newList != null)
            newList.CollectionChanged += ctrl.OnItemsCollectionChanged;
    }
