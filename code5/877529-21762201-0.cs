    private volatile int isRunning = 0;
    public void Tick()
    {
        if (Interlocked.Exchange(ref isRunning, 1) == 0)
        {
            try
            {
                //do stuff
            }
            finally
            {
                isRunning = 0;
            }
        }
    }
