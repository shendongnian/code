    public static class Week
    {
        public static IEnumerable<DateTime> UpTo(DateTime upTo)
        {
            var lastMonday = upTo.DayOfWeek == DayOfWeek.Sunday
                ? upTo.AddDays(-6)
                : upTo.AddDays(-(int) upTo.DayOfWeek + 1);
            var lastSunday = lastMonday.AddDays(-1);
            var firstDayOfMonth = new DateTime(lastSunday.Year, lastSunday.Month, 1);
            var sundayBefore = lastMonday.AddDays(-8);
            var startDay = firstDayOfMonth >= sundayBefore ? firstDayOfMonth : sundayBefore;
            for (var day = startDay; day < lastSunday; day = day.AddDays(1))
                yield return day;
        }
    }
