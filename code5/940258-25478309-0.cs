    object result;
    try
    {
        result = task.Result;
    }
    // catch (OperationCanceledException oce) // don't rely on oce.CancellationToken
    catch (Exception ex)
    {
        if (task.IsCancelled)
            return; // or otherwise handle cancellation
        // alternatively
        if (cancelSource.IsCancellationRequested)
            return; // or otherwise handle cancellation
        LogOrHandleError(ex);
    }
