    public class UnixTime
    {
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        public int unixFormat3(string dateTimeInput, string inputFormat, int hours)
        {
            int unixTime = -1;
            DateTime result = DateTime.MinValue;
            if (DateTime.TryParseExact(dateTimeInput, inputFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out result))
            {
                unixTime = (int)(result.AddHours(hours).Subtract(UnixTime.Epoch)).TotalSeconds;
            }
            return unixTime;
        }
    }
