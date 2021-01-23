    LocalDateTime ldt = new LocalDateTime(2013, 09, 17, 0, 0);
    DateTimeZone tz = DateTimeZoneProviders.Tzdb["Europe/Istanbul"];
    ZonedDateTime zdt = ldt.InZoneLeniently(tz);
    Instant utc = zdt.ToInstant();
    Debug.WriteLine(utc);             // 2013-09-16T21:00:00Z
