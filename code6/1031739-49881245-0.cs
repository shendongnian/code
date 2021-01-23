    var zone = NodaTime.TimeZones.TzdbDateTimeZoneSource.Default.ForId("Europe/London");
    var zonedClock = NodaTime.SystemClock.Instance.InZone(zone);
    var zonedDateTime = zonedClock.GetCurrentZonedDateTime();
    bool isDST = zonedDateTime.IsDaylightSavingTime();
    Console.WriteLine(isDST);
