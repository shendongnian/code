    private readonly SemaphoreSlim _mutex = new SemaphoreSlim(10);
    async Task GetCreditHistoryOnBackgroundThreadAsync(string ssn)
    {
      await _mutex.WaitAsync();
      try
      {
        var history = await Task.Run(() => GetCreditHistory(ssn));
        // Update UI with credit history.
      }
      catch (Exception ex)
      {
        // Update UI with error details.
      }
      finally
      {
        _mutex.Release();
      }
    }
