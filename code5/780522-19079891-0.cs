    public async Task<ObservableCollection<T1>>selectAll()
    {
        var Items = await Win8StorageHelper.LoadData("person.dat", typeof(ObservableCollection<T1>));
        ObservableCollection<T1> ItemsList = new ObservableCollection<T1>();
        if (typeof(Int32) == Items.GetType())
        {
            //Not Needed anymore
        }
        else
        {
            ItemsList = (ObservableCollection<T1>)Items;
        }
        _list.Clear();
        foreach (T1 item in ItemsList)
        {
            _list.Add(item);
        }
        return _list;
    }
