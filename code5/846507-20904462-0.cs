    private SemaphoreSlim _mutex = new SemaphoreSlim(3);
    public async Task DoWorkAsync()
    {
      await _mutex.WaitAsync();
      try
      {
        ...
      }
      finally
      {
        _mutex.Release();
      }
    }
