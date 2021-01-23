    // Define your retry strategy: retry 3 times, 1 second apart.
    var retryStrategy = new FixedInterval(3, TimeSpan.FromSeconds(1));
    
    // Define your retry policy using the retry strategy and the Azure storage
    // transient fault detection strategy.
    var retryPolicy = 
      new RetryPolicy<StorageTransientErrorDetectionStrategy>(retryStrategy);
    
    // Do some work that may result in a transient fault.
    try
    {
      // Call a method that uses Azure storage and which may
      // throw a transient exception.
      retryPolicy.ExecuteAction(
        () =>
        {
            this.queue.CreateIfNotExist();
        });
    }
    catch (Exception)
    {
      // All of the retries failed.
    }
