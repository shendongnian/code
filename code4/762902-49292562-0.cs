    public void RunWithTimeout(Action action, TimeSpan timeout)
    {
        var task = Task.Run(action);
        var success = task.Wait(timeout);
        if (!success)
        {
            throw new TimeoutException();
        }
    }
