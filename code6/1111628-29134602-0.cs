    private async void ExecuteLoadJobCommandAsync()
    {
       await GetData(...);
    }
    private async void GetData(...)
    {
       var data = await _repo.GetData();
       Jobs.Add(data);
    }
