    public static class MyDateExtensions
    {
        public static DateTime BuildDateTime(this DateTime date, string time)
        {
            return date.Add(TimeSpan.Parse(time));
    
        }
    }
