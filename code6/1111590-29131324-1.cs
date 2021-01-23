    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    
    public SetStartAndEndDates(DateTime start, DateTime end)
    {
    	if (start <= end)
    	{
    		StartDate = start;
    		EndDate = end;
    	}
    	else
    	{
    		throw new InvalidDates();
    	}
    }
