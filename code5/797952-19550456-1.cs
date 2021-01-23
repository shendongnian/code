    public string MyPath
    {
        get { return _mypath; }
        set
        {
            _myPath = value;
            NotifyPropertyChanged(() => MyPath);
            UpdateMyPathAsync();
        }
    }
    public async Task UpdateMyPathAsync()
    {
        this.EnableUI = false; // Stop user from setting path again....
        await LoadSomeStuffFromMyPathAsync(MyPath); 
        this.EnableUI = true;
    }
