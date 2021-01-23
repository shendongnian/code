    public static IEnumerable<DateTimeOffset> GetNextDaysInZone(int count, DayOfWeek dayOfWeek, TimeSpan localTimeOfDay, string timeZoneId)
    {
        // get today in the time zone specified
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        DateTime today = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz).Date;
        // figure out how many days we are away from the target day of week
        int adjustment = today.DayOfWeek - dayOfWeek + (dayOfWeek > today.DayOfWeek ? 7 : 0);
        // calculate and return the results
        return Enumerable.Range(0, count)
            .Select(x =>
            {
                DateTime dt = today.AddDays(x * 7 - adjustment).Add(localTimeOfDay);
                TimeSpan offset = tz.GetUtcOffset(dt);
                return new DateTimeOffset(dt, offset);
            });
    }
