    static bool Between(DateTime startTime, DateTime endTime)
    {
        var currentTime = DateTime.Now;
        if (currentTime >= startTime && currentTime <= endTime)
            return true;
        return false;
    }
    static bool Between(TimeSpan startTime, TimeSpan endTime)
    {
        DateTime dt1 = new DateTime(startTime.Ticks);
        DateTime dt2 = new DateTime(endTime.Ticks);
            return Between(dt1, dt2);
    }
