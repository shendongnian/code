       protected TResult LogFailedOperations<TResult>(Func<TResult> action)
            {
                try
                {
                    return action();
                }
                catch (Exception ex)
                {
                    // Logic for logging from ex.Message
                }
            }
