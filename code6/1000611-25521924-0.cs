    public const int MAX_RETRY_COUNT = 3;
    private void ProcessItemsAsync(Item item, int retryCount)
    {        
        // Note: Exceptions thrown here will pop up
        // as AggregateException in Task.WaitAll()
        if (retryCount >= MAX_RETRY_COUNT)
            throw new InvalidOperationException(
                "The maximum amount of retries has been exceeded");
        retryCount++;
        // Either implement try-catch, or use conditional operator.
        try
        {
            // Do stuff with item
        }
        catch(Exception ex)
        {
            // Exception logging relevant? If not, just retry
            ProcessItemsAsync(item, retryCount);
        }
    }
