    public void SleepBadly(int millisecondsTimeout)
    {
        var stopTime = DateTime.UtcNow.AddMilliseconds(millisecondsTimeout);
        while (DateTime.UtcNow < stopTime) {}
        return;
    }
