    private object _updateTimeUnitLock = new object();
    private int nextUpdateTime = 0;
    public bool UpdateTimeUnit(TimeSpan timeUnit, TimeSpan dontUpdateBefore)
    {
        lock (_updateTimeUnitLock)
        {
            if ((nextUpdateTime == 0) || (nextUpdateTime <= Environment.TickCount))
            {
                TimeUnitMilliseconds = (int)timeUnit.TotalMilliseconds;
                nextUpdateTime = Environment.TickCount + (int)dontUpdateBefore.TotalMilliseconds;
    
                return true;
            }
    
            return false;
        }
    }
