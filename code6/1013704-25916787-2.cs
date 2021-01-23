    public static DateTime WeekStart(DateTime date)
    {
        while (date.DayOfWeek != DayOfWeek.Wednesday)
            date = date.AddDays(-1);
        return date;
    }
