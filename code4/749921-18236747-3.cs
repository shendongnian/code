    public static IEnumerable<DateTime> WorkDayBetween(DateTime start, DateTime end)
    {
        return DaysBetween(start, end)
            .Where(date => IsWorkDay(date));
    }
    //feel free to use alternate logic here, or to account for holidays, etc.
    private static bool IsWorksDay(DateTime date)
    {
        return date.DayOfWeek != DayOfWeek.Saturday
                        && date.DayOfWeek != DayOfWeek.Sunday;
    }
