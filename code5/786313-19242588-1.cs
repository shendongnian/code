    var semaphore = new SemaphoreSlim(degreeOfParallelism);
    var tasks = arrayOfItem.Select(
        async item =>
        {
            await semaphore.WaitAsync();
            try
            {
                return await api.GetResultFromAnotherService(item.id);
            }
            finally
            {
                sempahore.Release();
            }
        });
