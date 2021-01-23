    public int GetTimeInterval(DateTime dt)
    {
        DateTime now = DateTime.Now;
        if (dt <= now) {
            dt = dt.AddDays(1);
        }
        return (dt - now).TotalMilliseconds;
    }
