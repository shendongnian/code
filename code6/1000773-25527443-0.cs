    public static class DateTimeExtension
    {
      public static DateTime GetDay(this DateTime date)
      {
        return date.TimeOfDay > TimeSpan.FromHours(3) ? date.Date : date.AddDays(-1).Date;
      }
    }
