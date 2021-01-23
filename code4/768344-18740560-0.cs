    public static void DatesToPeriodConverter(DateTime start, DateTime? end , out string date, out string time)
    {
        if(!end.HasValue){
            end = DateTime.MinValue;
        }
    }
