    private ObservableCollection<myType> _oc = new ObservableCollection<myType>();
    
    public MyConstructor()
    {
        _oc.CollectionChanged += CollectionChanged;
    }
    
    private void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        //myCode
    }
