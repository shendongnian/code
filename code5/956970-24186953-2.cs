    private readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(initialCount: 1);
    public async Task InsertAsync<T>(T item)
    {
       await semaphoreSlim.WaitAsync();
       try
       {
          await asyncConnection.InsertAsync(item);
       }
       finally
       { 
          semaphoreSlim.Release();
       }
    }
    public async Task InsertOrUpdateAsync<T>(T item)
    {
       await semaphoreSlim.WaitAsync();
       try
       {      
          int count = await asyncConnection.UpdateAsync(item);
          if (0 == count) 
          {
             await asyncConnection.InsertAsync(item);
          }
       }
       finally
       {
          semaphoreSlim.Release();
       }
    }
