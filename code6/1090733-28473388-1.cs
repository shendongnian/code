    public static class IdGenerator
    {
        private static int lastId = 0;
        private static DateTime lastDate = DateTime.Now;
        public static string NewId()
        {
            // If last used date is different than today or last id is 9999 restart the counter.
            if (lastDate.Date != DateTime.Now.Date || lastId == 9999)
                lastId = 0;
            lastDate = DateTime.Now;
            return string.Format("{0:yyMMdd}{1:0000}", lastDate, ++lastId);
        }
    }
    // Usage
    IdGenerator.NewId()
