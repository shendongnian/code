    public Task SomeOperationAsync()
    {
        return Task.StartNew(
            () =>
            {
                throw new ArgumentException("Directly thrown.");
            });
    }
