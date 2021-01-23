    public static long ConvertToUnixTime(DateTime aDateTime)
    {
        var epochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return Convert.ToInt64((aDateTime - epochTime).TotalSeconds);
    }
