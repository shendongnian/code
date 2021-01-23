    public static class SystemTime
    {       
        public static Func<DateTime> UtcNow = () => DateTime.UtcNow;
        public static Func<DateTime> Now = () => DateTime.Now;
        public static Func<DateTime> Today = () => DateTime.Today;
        public static void Reset()
        {
            UtcNow = () => DateTime.UtcNow;
            Now = () => DateTime.Now;
            Today = () => DateTime.Today;            
        }
    }
