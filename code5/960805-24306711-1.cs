    spinner.IsBusy = true;
    try
    {
        Task t1 = Task.Run(() => dataX = loadX());
        Task t2 = Task.Run(() => dataY = loadY());
        Task t3 = Task.Run(() => dataZ = loadZ());
        await Task.WhenAll(t1, t2, t3);
    }
    finally
    {
        spinner.IsBusy = false;
    }
