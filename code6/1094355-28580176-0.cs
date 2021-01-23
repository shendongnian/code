    public async Task AbortAllAsyncWork()
    {
        CancellationTokenSource.Cancel();
        foreach (Task workingTask in workingTasks.Keys)
        {
            if (IsRunning(workingTask))
            {
                try
                {
                    await workingTask;
                }
                catch (OperationCanceledException oce)
                {
                    // Do something usefull
                }
            }
        }
    }
