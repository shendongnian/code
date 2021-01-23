    public static IEnumerable<DateTime> WorkDayBetween(DateTime start, DateTime end)
    {
        return DaysBetween(start, end)
            .Where(date => date.DayOfWeek != DayOfWeek.Saturday
                && date.DayOfWeek != DayOfWeek.Sunday);
    }
