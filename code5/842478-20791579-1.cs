    public static DateTime GetDay(int year, int month, int ordinal,
                                  DayOfWeek dayOfWeek, bool fromStart)
    {
        DateTime result = new DateTime(year, month, 1);
        if (!fromStart)
            result = result.AddMonths(1).AddDays(-1);
        int mult = fromStart ? 1 : -1;
        for (; result.DayOfWeek != dayOfWeek; result = result.AddDays(1 * mult));
        for (int i = 1; i < ordinal; result = result.AddDays(7 * mult), i++);
        return result;
    }
    // use like this
    // meaning: in 2013, in March, find the second Sunday, from the beginning
    GetDay(2013, 3, 2, DayOfWeek.Sunday, true); // US start, Mar 10
    GetDay(2013, 11, 1, DayOfWeek.Sunday, true); // US end, Nov 3
    GetDay(2013, 4, 1, DayOfWeek.Sunday, true); // MX start, Apr 7
    // meaning: in 2013, in October, find the first Sunday, from the end
    GetDay(2013, 10, 1, DayOfWeek.Sunday, false); // MX end, Oct 27
