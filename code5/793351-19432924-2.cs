    public T CallWithRetries(Func<T> function)
    {
        for (int attempt = 1; attempt <= MaxAttempts; attempt++)
        {
            try
            {
                return function();
            }
            catch(Exception e)
            {
                // TODO: Logging
            }
        }
        // TODO: Consider throwing AggregateException here
        return default(T);
    }
