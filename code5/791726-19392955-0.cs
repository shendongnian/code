    public async Task<T> RetryQuery<T>(Func<Task<T>> operation, int numberOfAttempts, int msecsBetweenRetries = 500)
    {
         while (numberOfAttempts > 0)
         {
              try
              {
                   T value = await operation();
                   return value;
              }
              catch
              {
                    // Failed case - retry
                    --numberOfAttempts;                   
              }
              await Task.Delay(msecsBetweenRetries);
         }
         throw new ApplicationException("Operation failed repeatedly");
    }
