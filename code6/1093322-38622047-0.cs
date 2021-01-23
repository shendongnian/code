    internal static class DateTimeOffsetExtensions
    {
        private const string Iso8601UtcDateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
        public static string ToIso8601DateTimeOffset(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToUniversalTime().ToString(Iso8601UtcDateTimeFormat);
        }
    }
