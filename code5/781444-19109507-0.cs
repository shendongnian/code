    // ----------------------------------------------------------------------
    public void PeriodIntersection()
    {
      // time periods
      ITimePeriodCollection periods = new TimePeriodCollection();
      periods.Add( new TimeRange( new DateTime( 2013, 9, 1, 11, 0, 0 ), new DateTime( 2013, 9, 1, 12, 0, 0 ) ) );
      periods.Add( new TimeRange( new DateTime( 2013, 9, 1, 12, 1, 0 ), new DateTime( 2013, 9, 1, 14, 0, 0 ) ) );
    
      // search range
      TimeRange searchRange = new TimeRange( new DateTime( 2013, 9, 1, 11, 30, 0 ), new DateTime( 2013, 9, 1, 13, 30, 0 ) );
    
      // intersections
      foreach ( TimeRange period in periods )
      {
        if ( period.IntersectsWith( searchRange ) )
        {
          Console.WriteLine( "Intersection: " + period.GetIntersection( searchRange ) );
        }
      }
      // > Intersection: 01.09.2013 11.30:00 - 12:00:00 | 0.00:30
      // > Intersection: 01.09.2013 12.01:00 - 13:30:00 | 0.01:29
    } // PeriodIntersection
