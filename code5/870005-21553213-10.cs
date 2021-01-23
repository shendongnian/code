    public bool Contains(DateTime date)
    {
    	DateTime startNoYear = new DateTime(1904, StartDate.Month, StartDate.Day);
    	DateTime endNoYear = new DateTime(1904, EndDate.Month, EndDate.Day);
    	DateTime dateNoYear = new DateTime(1904, date.Month, date.Day);
    	
    	return dateNoYear >= startNoYear && dateNoYear <= endNoYear;
    }
