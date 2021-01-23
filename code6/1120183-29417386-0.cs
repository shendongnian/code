    private bool WaitForTrue(
        Func<bool> action, TimeSpan waitTime, TimeSpan checkInterval)
    {
        using(var mutie = new Mutex())
        {
            DateTime end = DateTime.UtcNow + waitTime;
            while (DateTime.UtcNow < end)
            {
                if (action())
                {
                    return true;
                }
                mutie.WaitOne(checkInterval);
            }    
            return action();
        }
    }
