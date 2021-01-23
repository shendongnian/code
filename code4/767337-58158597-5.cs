    await DoAsync(name).ContinueWith(task =>
    {
        if (task.Result is StorageFile sf)
        {
            // handle success
        }
    }, TaskContinuationOptions.OnlyOnRanToCompletion).ContinueWith(task =>
    {
        if (task.Exception is Exception ex)
        {
            // handle error
        }
    }, TaskContinuationOptions.NotOnRanToCompletion);
