       public static class DateTimeExtensions
        {
            public static DateTime LastDayOfWeek(this DateTime _date, DayOfWeek dayofweek)
            {
                return _date.AddDays(-1 * ((_date.DayOfWeek - dayofweek) % 7)).Date;
            }
        }
