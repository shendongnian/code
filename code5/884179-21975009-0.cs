    Instant now = SystemClock.Instance.Now;
    DateTimeZone tz = DateTimeZoneProviders.Tzdb["America/Phoenix"];
    ZonedDateTime zdt = now.InZone(tz);
            
    // Then depending on what your needs are, pick one of the following:
    LocalDateTime ldt = zdt.LocalDateTime;
    DateTime dt = zdt.ToDateTimeUnspecified();
    DateTimeOffset dto = zdt.ToDateTimeOffset();
