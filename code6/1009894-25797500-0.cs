    public Task<MyData> GetDataAsync()
    {
        if (_getDataTask == null)
        {
            _getDataTask = Task.Run(() => synchronousDataAccessMethod());
        }
        return _getDataTask;
    }
