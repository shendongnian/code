    public static async Task HandleAsync()
    {
        try
        {
            await TaskReturning();
            // Add to cache.
        }
        catch
        {
            // handle exception from both the synchronous and asynchronous parts.
        }
    }
