    public static double ToEpochDateHighCharts(this DateTime date)
            {
                TimeSpan t = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Utc) - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    
                return t.TotalMilliseconds;
            }
