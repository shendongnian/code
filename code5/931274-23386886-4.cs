    public async Task ProcessAsync()
    {
        await Task.Delay(1000);
        Task<string> workTask = SimulateWork();
        return workTask; 
    }
