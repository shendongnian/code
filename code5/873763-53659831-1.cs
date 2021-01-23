    public static Task IgnoreExceptions(this Task task)
    {
        var t = task.ContinueWith(c => { var ignored = c.Exception; },
            TaskContinuationOptions.OnlyOnFaulted |
            TaskContinuationOptions.ExecuteSynchronously);
        return t;
    }
