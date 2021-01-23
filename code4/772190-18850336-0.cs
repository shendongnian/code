    // ----------------------------------------------------------------------
    class CarPeriod : DayTimeRange
    {
    
      // --------------------------------------------------------------------
      public CarPeriod( int id, DateTime start, DateTime end ) :
        this( id, start, end.Date.AddDays( 1 ).Subtract( start.Date ).Days )
      {
      } // CarPeriod
    
      // --------------------------------------------------------------------
      public CarPeriod( int id, DateTime start, int days ) :
        base( start.Year, start.Month, start.Day, days )
      {
        Id = id;
      } // CarPeriod
    
      // --------------------------------------------------------------------
      public int Id { get; private set; }
    
    } // class CarPeriod
    
    // ----------------------------------------------------------------------
    [Sample( "DaysTrendData" )]
    public void DaysTrendData()
    {
      // periods
      ITimePeriodCollection carPeriods = new TimePeriodCollection();
      carPeriods.Add( new CarPeriod( 1, new DateTime( 2013, 1, 1 ), new DateTime( 2013, 1, 1 ) ) );
      carPeriods.Add( new CarPeriod( 2, new DateTime( 2013, 1, 2 ), new DateTime( 2013, 1, 2 ) ) );
      carPeriods.Add( new CarPeriod( 3, new DateTime( 2013, 1, 2 ), new DateTime( 2013, 1, 3 ) ) );
      carPeriods.Add( new CarPeriod( 4, new DateTime( 2013, 1, 3 ), new DateTime( 2013, 1, 3 ) ) );
      carPeriods.Add( new CarPeriod( 5, new DateTime( 2013, 1, 3 ), new DateTime( 2013, 1, 5 ) ) );
      carPeriods.Add( new CarPeriod( 6, new DateTime( 2013, 1, 4 ), new DateTime( 2013, 1, 5 ) ) );
    
      Days testDays = new Days( new DateTime( 2013, 1, 1 ), 5 );
      foreach ( Day testDay in testDays.GetDays() )
      {
        Console.Write( "Day: " + testDay + ": " );
        foreach ( CarPeriod carPeriod in carPeriods )
        {
          if ( carPeriod.IntersectsWith( testDay ) )
          {
            Console.Write( carPeriod.Id + " " );
          }
        }
        Console.WriteLine();
      }
    } // DaysTrendData
