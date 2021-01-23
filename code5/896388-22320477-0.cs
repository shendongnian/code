    struct Date : IFormattable
    {
        readonly DateTime value;
        public Date(DateTime dateAndTime)
        {
            value = dateAndTime.Date;
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return value.ToString(format ?? "d", formatProvider);
        }
        public string ToString(string format)
        {
            return ToString(format, null);
        }
        public string ToString(IFormatProvider formatProvider)
        {
            return ToString(null, formatProvider);
        }
        public override string ToString()
        {
            return ToString(null, null);
        }
        public static implicit operator DateTime(Date date)
        {
            return date.value;
        }
    }
