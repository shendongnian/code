    public static class TimeSpanEx
    {
        public static TimeSpan MultiplyBy (this TimeSpan t, int multiplier)
        {
            return new TimeSpan(t.Ticks * multiplier);
        }
    }
