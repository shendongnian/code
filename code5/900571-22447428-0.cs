    public class Holiday
    {
        public int Day {get; private set;}
        public int Month {get; private set;}
        public Holiday(int day, int month)
        {
            this.Day = day;
            this.Month = month;
        }
        public bool IsEqual(DateTime dateTime)
        {
            return ((this.Day == dateTime.Day) && (this.Month == dateTime.Month));
        }
    }
    public static class DateTimeExtensions
    {
        private static List<Holiday> holidays = new List<Holiday>();
        public static void RegisterHoliday(Holiday holiday)
        {
            holidays.Add(holiday);
        }
        public static bool IsHoliday(this DateTime dateTime)
        {
            foreach (Holiday holiday in holidays)
            {
                if (holiday.IsEqual(dateTime)) return true;
            }
            return false;
        }
        public static bool IsWeekend(this DateTime dateTime)
        {
            return (dateTime.DayOfWeek == DayOfWeek.Sunday) || (dateTime.DayOfWeek == DayOfWeek.Saturday);
        }
    }
