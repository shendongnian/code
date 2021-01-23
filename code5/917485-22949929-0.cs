        public static class DateTimeExtensions
        {
            public static DateTime ToNearestSecond(this DateTime date)
            {
                var rounded = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
                
                return date.Millisecond >= 500 ? rounded.AddSeconds(1) : rounded;
            }
        }
