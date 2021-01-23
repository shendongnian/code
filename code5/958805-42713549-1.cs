    public static DateTime FirstDayOfMonth(this DateTime value)
    {
        return new DateTime(value.Year, value.Month, 1);
    }
    public static DateTime LastDayOfMonth(this DateTime value)
    {
        return value.FirstDayOfMonth()
            .AddMonths(1)
            .AddMinutes(-1);
    }
