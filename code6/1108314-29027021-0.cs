    public static DateTime GetFirstSundayOfNextMonth(DateTime givenDate)
    {
        DateTime firstDayNextMonth = givenDate.AddDays(-givenDate.Day + 1).AddMonths(1);
        int diff = 7 - (int)firstDayNextMonth.DayOfWeek;
        return firstDayNextMonth.AddDays(diff);
    }
