    public Task _dataTask;
    protected override void OnStart()
    {
        _dataTask = MyService.GetDataAsync();
    }
    
    public Task AwaitInitializationAsync()
    {
        return _dataTask;
    }
