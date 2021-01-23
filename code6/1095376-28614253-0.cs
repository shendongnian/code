    private static readonly DateTime UnixEpoch =
        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public long GetUnixTimestamp()
    {
        TimeSpan diff = DateTime.UtcNow - UnixEpoch;
        return (long) diff.TotalSeconds;
    }
