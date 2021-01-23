    public DateTime FromUnixTime(long unixTime)
    {
        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return epoch.AddMilliseconds(unixTime);
    }
    var date = FromUnixTime(1415115303410); // 11/4/2014 3:35:03 PM
