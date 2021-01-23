    public static DateTime PreviousOfWeek(this DateTime dt, DayOfWeek dayOfWeek)
    {
       int offsetDays = -(dt.DayOfWeek - dayOfWeek);
       return dt.AddDays(offsetDays).AtMidnight();
    }
 
