    private static void Main()
    {
        try
        {
            AsyncMain().Wait();
        }
        catch (AggregateException aggEx)
        {
            foreach (Exception ex in taskEx.InnerExceptions)
            {
                // Handle your original exception here.
            }
        }
    }
