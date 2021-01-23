    // ----------------------------------------------------------------------
    public DateTime GetLatestBusinessHour( DateTime moment )
    {
      CalendarPeriodCollectorFilter filter = new CalendarPeriodCollectorFilter();
      filter.AddWorkingWeekDays();
      filter.CollectingHours.Add( new HourRange( 9, 17 ) );
    
      CalendarPeriodCollector collector = new CalendarPeriodCollector( filter,
        new TimeRange( moment.AddDays( -7 ), moment ) );
      collector.CollectHours();
      if ( collector.Periods.Count == 0 )
      {
        return moment;
      }
      return collector.Periods[ collector.Periods.Count - 1 ].End;
    } // GetLatestBusinessHour
