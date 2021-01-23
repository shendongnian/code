    public Task DoWork()
    {
        return DoWork(CancellationToken.None);
    }
    public Task DoWork(CancellationToken cancellationToken)
    {
        ...
    }
