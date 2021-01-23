    public static DateTime ConvertToEasternTimeZoneFromUtc(DateTime utcDateTime)
    {
        var easternTimeZone = DateTimeZoneProviders.Tzdb["America/New_York"];
        return Instant.FromDateTimeUtc(utcDateTime)
                      .InZone(easternTimeZone)
                      .ToDateTimeUnspecified();
    }
