    public static class DateTimeExtensions
    {
        static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        static readonly double _maxUnixSeconds = (DateTime.MaxValue - _unixEpoch).TotalSeconds;
        /// <summary>
        /// Converts .NET <c>DateTime</c> to Unix timestamp used in JavaScript
        /// </summary>
        /// <param name="dateTime">DateTime to convert</param>
        /// <returns>Unix timestamp in seconds</returns>
        public static long ToUnixTimestamp(this DateTime dateTime)
        {
            return (long)(dateTime - _unixEpoch).TotalSeconds;
        }
        public static DateTime FromUnixTimestamp(long seconds)
        {
            return _unixEpoch.AddSeconds(seconds);
        }
        public static DateTime? FromUnixTimestamp(string seconds)
        {
            long secondsNo;
            if(String.IsNullOrEmpty(seconds) || !long.TryParse(seconds, out secondsNo))
            {
               retun null;
            }
            return _unixEpoch.AddSeconds(secondsNo);
        }
    }
