    public DateTime GetStart()
    {
        int hour = int.Parse(StartTime.Substring(0, 2));
        int minute = int.Parse(StartTime.Substring(3, 2));
        
        return new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, hour, minute, 0);
    }
    
    public DateTime GetEnd()
    {
        int hour = int.Parse(EndTime.Substring(0, 2));
        int minute = int.Parse(EndTime.Substring(3, 2));
        
        return new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, hour, minute, 0);
    }
