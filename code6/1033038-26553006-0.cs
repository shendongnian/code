    internal static class DateTimeExtension
    {
        internal static DateTime BuildDateTime(this DateTime date, string time)
        {
            return date.Add(TimeSpan.Parse(time));
        }
    }
