    public Task SomeOperationAsync()
    {
        return Task.StartNew(
            () =>
            {
                throw new ArgumentException("Directly thrown.");
            });
    }
    public async Task SomeOtherOperationAsync()
    {
        throw new ArgumentException("async functions never throw exceptions directly.");
    }
