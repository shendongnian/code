    public bool Contains(DateTime date)
    {
    	DateTime startNoYear = new DateTime(StartDate.Day, StartDate.Month, 1904);
    	DateTime endNoYear = new DateTime(EndDate.Day, EndDate.Month, 1904);
    	DateTime dateNoYear = new DateTime(date.Day, date.Month, 1904;
    	
    	return dateNoYear >= startNoYear && dateNoYear <= endNoYear;
    }
