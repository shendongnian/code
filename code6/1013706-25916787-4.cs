    public static DateTime StartOfWeek(DateTime date)
    {
        while (date.DayOfWeek != DayOfWeek.Wednesday)
            date = date.AddDays(-1);
        return date;
    }
