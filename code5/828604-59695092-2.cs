    public static class DateHelper
    {
        public static DateTime GetDateForLastDayOfWeek(DayOfWeek DOW, DateTime DATE)
        {
            int adjustment = ((int)DATE.DayOfWeek < (int)DOW ? 7 : 0);
            return DATE.AddDays(0- (((int)(DATE.DayOfWeek) + adjustment) - (int)DOW));
        }
        public static DateTime GetDateForNextDayOfWeek(DayOfWeek DOW, DateTime DATE)
        {
            int adjustment = ((int)DATE.DayOfWeek < (int)DOW ? 0 : 7);
            return DATE.AddDays(((int)DOW) - ((int)(DATE.DayOfWeek)) + adjustment);
        }
    }
