    public double ConvertToTimestamp(DateTime value)
    {
        //create Timespan by subtracting the value provided from
        //the Unix Epoch
        TimeSpan span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
        //return the total milliseconds (which is a UNIX timestamp * 1000)
        return (long)span.TotalMilliseconds;
    }
