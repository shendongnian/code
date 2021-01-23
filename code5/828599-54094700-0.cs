        public static DateTime GetPrevious(this DateTime date, DayOfWeek dayOfWeek)
        {
            var lastDay = date.AddDays(-1);
            while (lastDay.DayOfWeek != dayOfWeek)
            {
                lastDay = lastDay.AddDays(-1);
            }
            return lastDay;
        }
        public static DateTime GetNext(this DateTime date, DayOfWeek dayOfWeek)
        {
            var nextDay = date.AddDays(+1);
            while (nextDay.DayOfWeek != dayOfWeek)
            {
                nextDay = nextDay.AddDays(+1);
            }
            return nextDay;
        }
