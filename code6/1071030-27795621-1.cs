    public bool Contains(DayOfWeek day)
    {
        var date = Start;
    
        while(date <= End)
        {
            if (date.DayOfWeek == day)
               return true;
    
            date = date.AddDays(1);
        }
    
        return false;
    }
