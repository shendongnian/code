    public async Task<bool> MutexWithAsync()
    {
        // Create OS-wide named object. (It will not use WaitOne/Release)
        using (Mutex myMutex = new Mutex(false, "My mutex Name", out var owned))
        {
            if (owned)
            {
                // New named-object was created. We own it.
                try
                {
                    await DoSomething();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                // The mutex was created by another process.
                // Exit this instance of process.
            }
        }
    }
