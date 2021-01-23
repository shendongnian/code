    bool AreFallingInSameWeek(DateTime date1, DateTime date2, DayOfWeek weekStartsOn)
    {
    	return date1.AddDays(-GetOffsetedDayofWeek(date1.DayOfWeek, (int)weekStartsOn)) == date2.AddDays(-GetOffsetedDayofWeek(date2.DayOfWeek, (int)weekStartsOn));
    }
    
    int GetOffsetedDayofWeek(DayOfWeek dayOfWeek, int offsetBy)
    {
    	return (((int)dayOfWeek - offsetBy + 7) % 7)
    }
