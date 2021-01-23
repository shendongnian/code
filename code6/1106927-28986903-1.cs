    private Task pendingTask = Task.FromResult(0);
    private async void Button1Click()
    {
        if (!pendingTask.IsCompleted)
        {
            //Notify the user
            return;
        }
        pendingTask = DoSomethingAsync();
        await pendingTask;
        ...
    }
    private async  void Button2Click()
    {
        if (!pendingTask.IsCompleted)
        {
            //Notify the user
            return;
        }
        pendingTask = DoSomethingElseAsync();
        await pendingTask;
        ...
    }
