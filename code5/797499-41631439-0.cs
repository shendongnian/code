    public static class DateExtension
    {
        public DateTime ToDateOnly(this DateTime d)
        {
           return new DateTime(d.Year, d.Month, d.Day);
        }
    }
