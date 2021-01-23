    public static IEnumerable<ZonedDateTime> GetNextDaysInZone(int count, IsoDayOfWeek dayOfWeek, LocalTime localTimeOfDay, string timeZoneId)
    {
        // get today in the time zone specified
        DateTimeZone tz = DateTimeZoneProviders.Tzdb[timeZoneId];
        Instant now = SystemClock.Instance.Now;
        LocalDate today = now.InZone(tz).Date;
            
        // figure out how many days we are away from the target day of week
        int adjustment = dayOfWeek - today.IsoDayOfWeek + (dayOfWeek < today.IsoDayOfWeek ? 7 : 0);
        // calculate and return the results
        return Enumerable.Range(0, count)
            .Select(x => (today.PlusDays(x * 7 + adjustment) + localTimeOfDay).InZoneLeniently(tz));
    }
