    public DateTime PreviousWorkDay(DateTime date)
    {
        do 
        {        
            date = date.AddDays(-1);        
        } 
        while(IsHoliday(date) || IsWeekend(date));
    
        return date;
    }
    
    private bool IsWeekend(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Saturday ||
               date.DayOfWeek == DayOfWeek.Sunday;
    }   
