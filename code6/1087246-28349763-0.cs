    public static void Invoke(Action action, int tryCount, TimeSpan tryInterval)
    {
        if (tryCount < 1)
        {
            throw new ArgumentOutOfRangeException("tryCount");
        }
        while (true)
        {
            try
            {
                action();
                return;
            }
            catch (Exception ex)
            {
                if (--tryCount > 0)
                {
                    Thread.Sleep(tryInterval);
                    continue;
                }
                LogError(ex.ToString());
                throw;
            }
        }       
    }
