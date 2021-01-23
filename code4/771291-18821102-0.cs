    public static class DateTimeExtensions
    {
        ...
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1);
        public static long ToUnixTime(this DateTime dateTime)
        {
            return (dateTime - UnixEpoch).Ticks / TimeSpan.TicksPerMillisecond;
        }
        ...
    }
