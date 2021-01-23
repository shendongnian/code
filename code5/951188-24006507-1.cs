    public static class TimeSpanExtensions
    {
        public static TimeSpan RoundToNearest15Mins(this TimeSpan input)
        {
            var totalMinutes = (int)(input + new TimeSpan(0, 7, 0)).TotalMinutes;
            return new TimeSpan(0, totalMinutes - totalMinutes % 15, 0);
        }
    }
