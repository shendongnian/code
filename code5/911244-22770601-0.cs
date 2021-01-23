    public static class DateExt
    {
        public static string FormatAsSomething( this DateTime dt )
        {
            string format = "yyyy-MM-dd";
            string result = dt.ToString( format );
            return result;
        }
    }
