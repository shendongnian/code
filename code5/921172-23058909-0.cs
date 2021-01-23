    TimeSpan span= DateTime.Now.Subtract(DateTime.Now.Next(DayOfWeek.Sunday)+new TimeSpan(23, 59, 00););
    return span.TotalSeconds;
    public static DateTime Next(this DateTime from, DayOfWeek dayOfWeek)
    {
        int start = (int)from.DayOfWeek;
        int target = (int)dayOfWeek;
        if (target <= start)
            target += 7;
        return from.AddDays(target - start);
    }
