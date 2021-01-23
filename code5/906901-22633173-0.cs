    public async Task<T> RepeatAsync<T, TException>(Func<T> work, TimeSpan retryInterval, int maxExecutionCount = 3) where TException : Exception
    {
         for (var i = 0; i < maxExecutionCount; ++i)
         {
            try { return work(); }
            catch (TException ex)
            {
                // allow the program to continue in this case
            }
            // this will use a system timer under the hood, so no thread is consumed while
            // waiting
            await Task.Delay(retryInterval);
         }
    }
