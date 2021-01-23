    using NodaTime;
    using NodaTime.Text;
    LocalDateTimePattern pattern = LocalDateTimePattern
                                     .CreateWithInvariantCulture("M/dd/yyyy h:mmtt");
    LocalDateTime ldt = pattern.Parse("8/14/2013 5:51am").Value;
    DateTimeZone tz = DateTimeZoneProviders.Tzdb["America/New_York"];
    ZonedDateTime zdt = tz.AtLeniently(ldt);
    Instant instant = zdt.ToInstant();
    Debug.WriteLine(instant.ToString());  // 2013-08-14T09:51:00Z   (UTC)
    // if you need it as a DateTime
    DateTime utc = instant.ToDateTimeUtc();
