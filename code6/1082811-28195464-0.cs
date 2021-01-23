    //Coding conventions say async functions should end with the word Async.
    public Task<int> RunOnUiAsync(Func<int> f)
    {
        var dispatcherOperation = Application.Current.Dispatcher.InvokeAsync(f);
        return dispatcherOperation.Task;
    }
