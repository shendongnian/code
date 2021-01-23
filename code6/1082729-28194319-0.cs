    public static DateTime NextDayOfWeek(this DateTime dt, DayOfWeek dayOfWeek)
    {
         int offsetDays = dayOfWeek - dt.DayOfWeek;
         return dt.AddDays(offsetDays > 0 ? offsetDays : offsetDays + 7).AtMidnight();
    }
