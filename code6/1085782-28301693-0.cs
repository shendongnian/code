    public static DateTime WithDate(this DateTime start, DateTime date)
    {
        // No need to use the Date property if you already know
        // it will be midnight...
        return date.Date + start.TimeOfDay;
    }
    public static DateTime WithFloorDate(this DateTime start)
    {
        return start.WithDate(FloorDate);
    }
