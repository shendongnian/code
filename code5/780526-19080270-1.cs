    public async Task<ObservableCollection<T>> selectAllItems<T>(ObservableCollection<T> _list)
    {
        var items = await Win8StorageHelper.LoadData(string.Format("{0}.dat",typeof(T).Name.ToLower()), typeof(ObservableCollection<T>));
        _list.Clear();
        if(!(items is ObservableCollection<T>))
        {
             return _list;
        }
        ObservableCollection<T> itemsList = (ObservableCollection<T>)items;        
        foreach (T item in itemsList)
        {
            _list.Add(item);
        }
        return _list;
    }
