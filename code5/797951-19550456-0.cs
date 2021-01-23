    public string MyPath
    {
        get { return _mypath; }
    }
    public async Task UpdateMyPathAsync()
    {
            _mypath = value;
            NotifyPropertyChanged(() => MyPath);
            await LoadSomeStuffFromMyPathAsync(mypath); // Don't worry about when it finishes
    }
