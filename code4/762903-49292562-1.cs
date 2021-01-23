    public void RunWithTimeout(Action action, TimeSpan timeout)
    {
        var task = Task.Run(action);
        try
        {
            var success = task.Wait(timeout);
            if (!success)
            {
                throw new TimeoutException();
            }
        }
        catch (AggregateException ex)
        {
            throw ex.InnerException;
        }
    }
