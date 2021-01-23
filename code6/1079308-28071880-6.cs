    public async Task Start()
    {
      var tasks = products.Select(product =>
          ProcessAvailabilityAsync(product.ID, cts.Token));
      await Task.WhenAll(tasks);
    }
    private SemaphoreSlim mutex = new SempahoreSlim(2);
    private async Task ProcessAvailabilityAsync(int id, CancellationToken token)
    {
      await mutex.WaitAsync();
      try
      {
        var result = await RetrieveProductAvailability(id, token);
        // Logic for reporting results
      }
      finally
      {
        mutex.Release();
      }
    }
