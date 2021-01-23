    public bool Contains(DateTime date)
    {
    	DateTime startNoYear = new DateTime(StartDate.Day, StartDate.Month, 2000);
    	DateTime endNoYear = new DateTime(EndDate.Day, EndDate.Month, 2000);
    	DateTime dateNoYear = new DateTime(date.Day, date.Month, 2000);
    	
    	return dateNoYear >= startNoYear && dateNoYear <= endNoYear;
    }
