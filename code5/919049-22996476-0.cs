    // ----------------------------------------------------------------------
    public void WeekOfYear()
    {
    	Week week = new Week( 2014, 14 );
    	Console.WriteLine( "Week: {0}", week );
    	Console.WriteLine( "Year: {0}, Month: {1}", week.Start.Year, week.Start.Month );
    	Console.WriteLine( "NextWeek: {0}", week.GetNextWeek() );
    } // WeekOfYear
