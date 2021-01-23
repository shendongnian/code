    {
        DateTime lastReset = DateTime.Min;
        TimeSpan resetInterval = TimeSpan.FromMinutes(50);
        
        foreach (var whatever in enumerable)
        {
            if ((DateTime.Now - lastReset) > resetInterval)
            {
                ResetAuthToken();
                lastReset = DateTime.Now;
            }
            ProcessWhatever();
        }
    }
