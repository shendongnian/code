    public static class Week
    {
        public static IEnumerable<DateTime> UpTo(DateTime upTo)
        {
            var lastMonday = upTo.AddDays(-(int) upTo.DayOfWeek + 1);
            var lastSunday = lastMonday.AddDays(-1);
            var sundayBefore = lastSunday.AddDays(-7);
            var firstDayOfMonth = new DateTime(lastSunday.Year, lastSunday.Month, 1);
            var startDay = firstDayOfMonth >= sundayBefore ? firstDayOfMonth : sundayBefore;
            for (var day = startDay; day < lastSunday; day = day.AddDays(1))
                yield return day;
        }
    }
