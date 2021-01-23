    // ----------------------------------------------------------------------
    public DateTime GetLatestBusinessHour( DateTime moment )
    {
      // filter the business hours: - Monday to Friday, 9AM to 5PM
      CalendarPeriodCollectorFilter filter = new CalendarPeriodCollectorFilter();
      filter.AddWorkingWeekDays();
      filter.CollectingHours.Add( new HourRange( 9, 17 ) );
    
      // collect business hours of the past week
      CalendarPeriodCollector collector = new CalendarPeriodCollector( filter,
        new TimeRange( moment.AddDays( -7 ), moment ), SeekDirection.Forward,
        new TimeCalendar( new TimeCalendarConfig { EndOffset = TimeSpan.Zero } ) );
      collector.CollectHours();
    
      // end of the last period
      return collector.Periods.End;
    } // GetLatestBusinessHour
