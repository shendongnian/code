    private int retryCount = 3;
    ...
    
    public async Task OperationWithBasicRetryAsync()
    {
      int currentRetry = 0;
    
      for (; ;)
      {
        try
        {
          // Calling external service.
          await TransientOperationAsync();
                        
          // Return or break.
          break;
        }
        catch (Exception ex)
        {
          Trace.TraceError("Operation Exception");
    
          currentRetry++;
    
          // Check if the exception thrown was a transient exception
          // based on the logic in the error detection strategy.
          // Determine whether to retry the operation, as well as how 
          // long to wait, based on the retry strategy.
          if (currentRetry > this.retryCount || !IsTransient(ex))
          {
            // If this is not a transient error 
            // or we should not retry re-throw the exception. 
            throw;
          }
        }
    
        // Wait to retry the operation.
        // Consider calculating an exponential delay here and 
        // using a strategy best suited for the operation and fault.
        Await.Task.Delay();
      }
    }
    
    // Async method that wraps a call to a remote service (details not shown).
    private async Task TransientOperationAsync()
    {
      ...
    }
