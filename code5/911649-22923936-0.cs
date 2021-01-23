    // ----------------------------------------------------------------------
    public void NightHours()
    {
    	CalendarPeriodCollectorFilter filter = new CalendarPeriodCollectorFilter();
    	filter.CollectingHours.Add( new HourRange( 0, 5 ) ); // working hours
    	filter.CollectingHours.Add( new HourRange( 23, 24 ) ); // working hours
    
    	CalendarTimeRange testPeriod =
           new CalendarTimeRange( new DateTime( 2014, 4, 1 ), 
           new DateTime( 2014, 4, 3 ) );
    	Console.WriteLine( "Calendar period collector of period: " + testPeriod );
    
    	CalendarPeriodCollector collector =
    					new CalendarPeriodCollector( filter, testPeriod );
    	collector.CollectHours();
    	Console.WriteLine( "Duration: " + new DateDiff( collector.Periods.TotalDuration ) );
    } // NightHours
