    using Microsoft.Practices.TransientFaultHandling;
    using Microsoft.Practices.EnterpriseLibrary.WindowsAzure.TransientFaultHandling;
    ...
    // Define your retry strategy: retry 5 times, starting 1 second apart
    // and adding 2 seconds to the interval each retry.
    var retryStrategy = new Incremental(5, TimeSpan.FromSeconds(1), 
      TimeSpan.FromSeconds(2));
    
    // Define your retry policy using the retry strategy and the Windows Azure storage
    // transient fault detection strategy.
    var retryPolicy =
      new RetryPolicy<StorageTransientErrorDetectionStrategy>(retryStrategy);
    
    // Receive notifications about retries.
    retryPolicy.Retrying += (sender, args) =>
        {
            // Log details of the retry.
            var msg = String.Format("Retry - Count:{0}, Delay:{1}, Exception:{2}",
                args.CurrentRetryCount, args.Delay, args.LastException);
            Trace.WriteLine(msg, "Information");
        };
    
    try
    {
      // Do some work that may result in a transient fault.
      retryPolicy.ExecuteAction(
        () =>
        {
            // Your method goes here!
        });
    }
    catch (Exception)
    {
      // All the retries failed.
    }
