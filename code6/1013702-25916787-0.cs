    public static DateTime WeekStart(DateTime date)
    {
        while (date.DayOfWeek != DayOfWeek.Monday)
            date = date.AddDays(-1);
        return date;
    }
