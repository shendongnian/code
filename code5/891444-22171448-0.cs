    private ObservableCollection<Point> points = new ObservableCollection<Point>();
    points.CollectionChanged += points_CollectionChanged;//Subscribe event
    void collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
       //Handle it below respectively
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                break;
            case NotifyCollectionChangedAction.Remove:
                break;
            case NotifyCollectionChangedAction.Replace:
                break;
            case NotifyCollectionChangedAction.Move:
                break;
            case NotifyCollectionChangedAction.Reset:
               break;
        }            
    }
