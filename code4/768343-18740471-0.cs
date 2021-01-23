    public static void DatesToPeriodConverter(DateTime start, DateTime? end = null,
         out string date, out string time)
    {
        var effectiveEnd = end ?? DateTime.MinValue;
        // ...
    }
