    private static void OnTreeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var control = sender as ChartsControl;
        var oldCollection = e.OldValue as INotifyCollectionChanged;
        var newCollection = e.NewValue as INotifyCollectionChanged;
        if (oldCollection != null)
        {
            oldCollection.CollectionChanged -= control.Tree_CollectionChanged;
        }
        if (newCollection != null)
        {
            newCollection.CollectionChanged += control.Tree_CollectionChanged;
        }
    }
