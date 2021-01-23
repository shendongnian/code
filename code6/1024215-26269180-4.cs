    private AsyncLazy<object> initializeTask = new AsyncLazy<object>(async () =>
                {
                    // Do an action requiring await here
                    await _storageField.LoadAsync();
                    return null;
                });
    public Task InitializeAsync()
    {
        return _initializeTask.Value;
    }
