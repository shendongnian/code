    Tick_Handler(...)
    {
        if (UpdateThrottler.CanAcquire())
        {
            try
            {
            //Do your work
            }
            finally
            {
                UpdateThrottler.Release();
            }
        }
    }
