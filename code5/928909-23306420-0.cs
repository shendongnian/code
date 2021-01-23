    public void DivideBy(int divide)
    {
        locker.EnterWriteLock();
        try
        {
            x = x / divide;
        }
        finally
        {
            locker.ExitWriteLock();
        }
    }
