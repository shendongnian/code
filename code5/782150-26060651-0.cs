    public static class DateTimeExtensions
    {
        public static DateTime ToLocalTimeX(this DateTime dateTime)
        {
            var info = TimeZoneInfo.Local;
            return dateTime.Add(info.BaseUtcOffset.Add(TimeSpan.FromHours(info.IsDaylightSavingTime(DateTime.Now) ? 1 : 0)));
        }
    }
