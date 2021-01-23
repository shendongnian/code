    public static long MbtaDateTimeToUnixTimestamp(DateTime time)
    {
        var local = LocalDateTime.FromDateTime(time);
        var zoned = local.InZoneStrictly(mbtaTimeZone);
        var instant = zoned.ToInstant();
        return instant.Ticks / NodaConstants.TicksPerSecond;
    }
