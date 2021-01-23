    spinner.IsBusy = true;
    try
    {
        Task t1 = LoadXAsync();
        Task t2 = LoadYAsync();
        Task t3 = LoadZAsync();
        await Task.WhenAll(t1, t2, t3);
    }
    finally
    {
        spinner.IsBusy = false;
    }
