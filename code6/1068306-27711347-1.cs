    public static class UnixTimeHelper
    {
        const long MillisecondsToTicks = 10000;
        static readonly DateTime utcEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        static DateTime UtcEpochStart { get { return utcEpochStart; }}
        public static DateTime ToDateTime(long unixTimeInMs, DateTimeKind kind)
        {
            var dateTime = UtcEpochStart + new TimeSpan(MillisecondsToTicks * unixTimeInMs);
            if (kind == DateTimeKind.Local)
                dateTime = dateTime.ToLocalTime();
            return dateTime;
        }
        public static long ToUnixTimeInMs(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Local)
                dateTime = dateTime.ToUniversalTime();
            var span = dateTime - UtcEpochStart;
            return (long)(span.Ticks / MillisecondsToTicks);
        }
    }
