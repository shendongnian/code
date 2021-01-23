    static class Retry
    {
        public static T Invoke<T>(Func<T> func, int tryCount, TimeSpan tryInterval)
        {
            if (tryCount < 1)
            {
                throw new ArgumentOutOfRangeException("tryCount");
            }
            while (true)
            {
                try
                {
                    return func();
                }
                catch (Exception e)
                {
                    if (--tryCount > 0)
                    {
                        Thread.Sleep(tryInterval);
                        continue;
                    }
                    ErrorHandlingComponent.LogError(ex.ToString());
                    throw;
                }
            }
        }
    }
