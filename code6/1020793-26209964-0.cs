    public static class TestRetryExtensions 
    {
        public static void WithRetry<T>(this Action thingToTry, int timeout = 30) where T: Exception
        {
            var expiration = DateTime.Now.AddSeconds(timeout)
            while (true) 
            {
                try 
                {
                    thingToTry();
                    return;
                }
                catch (T) 
                {
                    if (DateTime.Now > expiration) 
                    {
                        throw;
                    }
                    Thread.Sleep(1000);
                }
            }
        }
    }
