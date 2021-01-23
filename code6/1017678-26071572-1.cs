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
        switch (e.Action)
        {
            case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                {
                    if (e.NewItems != null)
                    {
                        if (e.NewItems.Count > 0 && e.NewItems[0] is KeyValuePair<string, object>)
                        {
                            KeyValuePair<string, object> item = (KeyValuePair<string, object>)e.NewItems[0];
                            System.Diagnostics.Debug.WriteLine(string.Format("key = {0}, new value = {1}", item.Key, item.Value));
                        }
                    }
                    break;
                }
            case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                {
                    //new items added  
                    //break;
                }
            //cases for Remove/Reset.
                //break;
        } 
    }
