    public async Task<ObservableCollection<T1>> selectAll<T1>(string filename)
    {
        var Items = await Win8StorageHelper.LoadData(filename, typeof(ObservableCollection<T1>));
        if (Items is ObservableCollection<T1>)
        {
             return ((ObservableCollection<T1>)Items).ToList();
        }
        else
        {
            // empty or not the right type; depending on what the storage helper gives us
            return new ObservableCollection<T1>();
        }
    }
