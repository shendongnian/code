    // Get the current time
    IClock systemClock = SystemClock.Instance;
    Instant now = systemClock.Now;
    // Get the local time zone, and the current date
    DateTimeZone tz = DateTimeZoneProviders.Tzdb.GetSystemDefault();
    LocalDate today = now.InZone(tz).Date;
    // Get the start of the day, and the start of the next day as the end date
    ZonedDateTime dayStart = tz.AtStartOfDay(today);
    ZonedDateTime dayEnd = tz.AtStartOfDay(today.PlusDays(1));
    // Compare instants using inclusive start and exclusive end
    ZonedDateTime other = new ZonedDateTime(); // some other value
    bool between = dayStart.ToInstant() <= other.ToInstant() &&
                   dayEnd.ToInstant() > other.ToInstant();
