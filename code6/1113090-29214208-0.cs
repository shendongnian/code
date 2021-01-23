    try
    {
        var response = task.Result;
    }
    catch (TaskCanceledException ex)
    {
        // Check ex.CancellationToken.IsCancellationRequested here.
        // If false, it's pretty safe to assume it was a timeout.
    }
