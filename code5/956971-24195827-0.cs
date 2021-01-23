    private readonly AsyncLock _lock = new AsyncLock(); 
    
    public async Task InsertAsync<T> (T item)
    {
        using(await _lock.LockAsync())
        {
            await asyncConnection.InsertAsync (item);
        }
    }
    
    public async Task InsertOrUpdateAsync<T> (T item)
    {
        using(await _lock.LockAsync())
        {
            if (0 == await asyncConnection.UpdateAsync (item))
            {
                await asyncConnection.InsertAsync (item);
            }
        }
    }
