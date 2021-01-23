    static readonly DateTime _unixEpoch =
        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public static DateTime DateFromTimestamp(long timestamp)
    {
        return _unixEpoch.AddSeconds(timestamp);
    }
