    public static class LocalDateTime
    {
        public static string ToLocalDateTime(this DateTime dt)
        {
           return dt.ToString("dd/MM/yyy HH:mm:ss");
        }
    }
