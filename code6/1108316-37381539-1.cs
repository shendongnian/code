    public static DateTime FirstDayOfWeekOnOrAfter(this DateTime date, DayOfWeek dayOfWeek)
    {
      return date.AddDays(Math.Abs(dayOfWeek - date.DayOfWeek));
    }
    
    public static DateTime FirstDayOfWeekOnOrBefore(this DateTime date, DayOfWeek dayOfWeek)
    {
      return date.AddDays(-Math.Abs(dayOfWeek - date.DayOfWeek));
    }
