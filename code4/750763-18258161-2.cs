    static class AutoIncrement
    {
        private static long lastDate;
    
        public static DateTime Current
        {
            get
            {
                long lastDateOrig, lastDateNew;
                                
                do
                {
                    lastDateOrig = lastDate;
                    
                    lastDateNew = lastDateOrig + 1;
                    
                    lastDateNew = Math.Max(DateTime.UtcNow.Ticks, lastDateNew);
                }
                while (Interlocked.CompareExchange(ref lastDate, lastDateNew, lastDateOrig) != lastDateOrig);
                
                return new DateTime(lastDateNew, DateTimeKind.Utc);
            }
        }
    }
    DateTime ac = AutoIncrement.Current;
    Console.WriteLine(CultureInfo.InvariantCulture, "{0} {1:yyyy/MM/dd HH:mm:ss.fffffff}", ac.Ticks, ac);
