    public static async Task AddAsync<TEntity>(
        this BlockingCollection<TEntity> Bc, TEntity item, CancellationToken abortCt)
    {
        while (true)
        {
            try
            {
                if (Bc.TryAdd(item, 0, abortCt))
                    return;
                else
                    await Task.Delay(100, abortCt);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public static async Task<TEntity> TakeAsync<TEntity>(
        this BlockingCollection<TEntity> Bc, CancellationToken abortCt)
    {
        while (true)
        {
            try
            {
                TEntity item;
                if (Bc.TryTake(out item, 0, abortCt))
                    return item;
                else
                    await Task.Delay(100, abortCt);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
