    void Main()
    {
        var t = new DateTime(2014, 8, 4, 11, 09, 24, DateTimeKind.Utc);
        var i = Instant.FromDateTimeUtc(t);
        var s = ConvertDateTimeToUserTimeZone(i);
        s.Dump("User time zone value");
    }
    
    public static string ConvertDateTimeToUserTimeZone(Instant now)
    {
        DateTimeZone dtZone = DateTimeZoneProviders.Tzdb["Europe/London"];
        dtZone.GetUtcOffset(now).Dump("TZ at instant");
        ZonedDateTime zdt = now.InZone(dtZone);
        return zdt.ToDateTimeOffset().ToString("G");
    }
