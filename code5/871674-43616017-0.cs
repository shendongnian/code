    public static class DateExtensions
    {
        private static void Swap<T>(ref T one, ref T two)
        {
            var temp = one;
            one = two;
            two = temp;
        }
        public static bool IsFromSameWeek(this DateTime first, DateTime second, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
        {
            // sort dates
            if (first > second)
            {
                Swap(ref first, ref second);
            }
            var daysDiff = (second - first).TotalDays;
            if (daysDiff >= 7)
            {
                return false;
            }
            const int TotalDaysInWeek = 7;
            var adjustedDayOfWeekFirst = (int)first.DayOfWeek + (first.DayOfWeek < firstDayOfWeek ? TotalDaysInWeek : 0);
            var adjustedDayOfWeekSecond = (int)second.DayOfWeek + (second.DayOfWeek < firstDayOfWeek ? TotalDaysInWeek : 0);
            return adjustedDayOfWeekSecond >= adjustedDayOfWeekFirst;
        }
    }
