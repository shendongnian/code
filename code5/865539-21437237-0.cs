    private T CallWithRetries<T>(Func<T> call)
    {
        // TODO: Work out number of retries, etc.
        for (int i = 0; i < 3; i++)
        {
            try
            {
                return call();
            }
            catch (FooException e)
            {
                // Determine whether or not to retry, log etc. If this is the
                // last iteration, just rethrow - or keep track of all the exceptions
                // so far and throw an AggregateException containing them.
            }
        }
        throw new InvalidOperationException("Shouldn't get here...");
    }
