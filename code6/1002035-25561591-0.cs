    public enum DateTimeType
    {
        Date,
        Time,
        DateAndTime
    }
    public static class DateTimeExtensions
    {
        private static readonly DateTime ZeroDate = new DateTime(1, 1, 1);
        public static DateTimeType GetDateTimeType(this DateTime value)
        {
            if (value.TimeOfDay == TimeSpan.Zero)
            {
                return DateTimeType.Date;
            }
            if (value.Date == ZeroDate)
            {
                return DateTimeType.Time;
            }
            return DateTimeType.DateAndTime;
        }
    }
