    var retryStrategy = new Incremental(3, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));
    var retryPolicy = new RetryPolicy<SimpleHandlerStartegy>(retryStrategy);
    
    retryPolicy.Retrying += (sender, retryArgs) =>
    			{
    				Console.WriteLine("Retrying {0}, Delay{1}, Last Exception: {2}", retryArgs.CurrentRetryCount, retryArgs.Delay, retryArgs.LastException);
    			};
    			
    // In real world, await this to get the return value
    retryPolicy.ExecuteAsync(() => SomeAsyncWorkThatThrows());    			
