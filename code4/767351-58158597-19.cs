    await DoAsync(name).ContinueWith(task =>
    {
        if (task.Exception != null)
        {
            // handle fail
        }
        if (task.Result is StorageFile sf)
        {
            // handle success
        }
    });
