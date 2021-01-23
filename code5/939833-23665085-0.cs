    // ----------------------------------------------------------------------
    public void FinalDateProvider()
    {
    	DateTime now = new DateTime( 2014, 5, 16, 9, 0, 0 );
    	TimeSpan offset = new TimeSpan( 15, 0, 0 );
    	Console.WriteLine( "{0} + {1} = {2}", now, offset, CalcFinalDate( now, offset ) );
    } // FinalDateProvider
    
    // ----------------------------------------------------------------------
    public DateTime? CalcFinalDate( DateTime start, TimeSpan offset )
    {
    	CalendarDateAdd dateAdd = new CalendarDateAdd();
    	dateAdd.AddWorkingWeekDays();
    	dateAdd.WorkingHours.Add( new HourRange( 8, 12 ) );
    	dateAdd.WorkingHours.Add( new HourRange( new Time( 12, 30 ), new Time( 17 ) ) );
    	return dateAdd.Add( start, offset );
    } // CalcFinalDate
