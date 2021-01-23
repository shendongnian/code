    public MyClass()
    {
        _dataGrid1Properties = new ObservableDictionary<string, object>();            
        _dataGrid1Properties.Add("Name", _name);
        //...add other properties
        //then wire up the CollectionChanged event
        _dataGrid1Properties.CollectionChanged += _dataGrid1Properties_CollectionChanged;
    }
    void _dataGrid1Properties_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        _name = (string)_dataGrid1Properties["Name"];
    }
