    public async Task DoSomethingToUserInterfaceAsync()
    {
        if (InvokeRequired)
        {
            await Task.Factory.StartNew(() => DoSomethingToUserInterface(), CancellationToken.None, TaskCreationOptions.None, uiScheduler);
        }
        ...
    }
