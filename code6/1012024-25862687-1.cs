    public static class Extensions
    {
        private const double DaysInYear = 365.242;
        private const double DaysInMonth = 30.4368;
        public static int GetMinutes(this TimeSpan ts)
        {
            return ts.Minutes;
        }
        public static int GetDays(this TimeSpan ts)
        {
            return (int)((ts.TotalDays % DaysInYear % DaysInMonth));
        }
        public static int GetMonths(this TimeSpan ts)
        {
            return (int)((ts.TotalDays % DaysInYear) / DaysInMonth);
        }
        public static int GetYears(this TimeSpan ts)
        {
            return (int)(ts.TotalDays / DaysInYear);
        }
    }
