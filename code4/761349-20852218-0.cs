    private SemaphoreSlim _semaphore = new SemaphoreSlim(N);
    public async Task<ResponseMessage> SendMessageAsync(RequestMessage message)
    {
      await _semaphore.WaitAsync();
      try
      {
        return await InternalMessageWithoutWaitingAsync(message);
      }
      finally
      {
        ReleaseSemaphoreAfterDelayAsync();
      }
    }
    private async Task ReleaseSemaphoreAfterDelayAsync()
    {
      await Task.Delay(TimeInterval);
      _semaphore.Release();
    }
