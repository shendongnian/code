    public Task ProcessAsync()
    {
        Task<string> workTask = SimulateWork();
        return workTask; 
    }
