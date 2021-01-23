    // Get the input value
    LocalDateTime ldt1 = new LocalDateTime(2010, 2, 8, 5, 0, 0);
    DateTimeZone tz1 = DateTimeZoneProviders.Tzdb["Australia/Perth"];
    ZonedDateTime zdt1 = ldt1.InZoneLeniently(tz1);
            
    // Convert to the target time zone
    DateTimeZone tz2 = DateTimeZoneProviders.Tzdb["America/New_York"];
    ZonedDateTime zdt2 = zdt1.WithZone(tz2);
    // If you need a DateTimeOffset, you can get one easily
    DateTimeOffset dto = zdt2.ToDateTimeOffset();
