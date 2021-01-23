    public class YourClass : IFormattable
    {
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == "Date")
                return DateTime.Now.ToString("yyyy/MM/d");
            if (format == "Time")
                return DateTime.Now.ToString("HH:mm");
            if (format == "DateTime")
                return DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return format;
            // or throw new NotSupportedException();
        }
    }
