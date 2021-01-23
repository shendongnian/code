    /// <summary>
    /// Try a given async action 'n' times or until it succeeds.
    /// </summary>
    /// <param name="times">The number of times to retry the action</param>
    /// <param name="action">The action to retry</param>
    /// <param name="pauseInMilliseconds">The amount of time in milliseconds to pause between retries (defaults to 0)</param>
    public async static Task<T> RetriesAsync<T>(this int times, Func<int, Task<T>> action, int pauseInMilliseconds)
    {
        var attempt = 0;
        var result = default(T);
        while (attempt < times)
        {
            try
            {
                result = await action(attempt);
                break;
            }
            catch (Exception)
            {
                attempt++;
                if (attempt >= times)
                {
                    throw;
                }
            }
            if (pauseInMilliseconds > 0)
            {
                await Task.Delay(pauseInMilliseconds);
            }
        }
        return result;
    }
