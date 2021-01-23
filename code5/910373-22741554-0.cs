    // ----------------------------------------------------------------------
    public void TimePeriodChainSample()
    {
      TimePeriodChain timePeriods = new TimePeriodChain();
    
      DateTime now = ClockProxy.Clock.Now;
      DateTime testDay = new DateTime( 2010, 7, 23 );
    
      // --- add ---
      timePeriods.Add( new TimeBlock(
                       TimeTrim.Hour( testDay, 8 ), Duration.Hours( 2 ) ) );
      timePeriods.Add( new TimeBlock( now, Duration.Hours( 1, 30 ) ) );
      timePeriods.Add( new TimeBlock( now, Duration.Hour ) );
      Console.WriteLine( "TimePeriodChain.Add(): " + timePeriods );
      // > TimePeriodChain.Add(): Count = 3; 23.07.2010 08:00:00 - 12:30:00 | 0.04:30
      foreach ( ITimePeriod timePeriod in timePeriods )
      {
        Console.WriteLine( "Item: " + timePeriod );
      }
      // > Item: 23.07.2010 08:00:00 - 10:00:00 | 02:00:00
      // > Item: 23.07.2010 10:00:00 - 11:30:00 | 01:30:00
      // > Item: 23.07.2010 11:30:00 - 12:30:00 | 01:00:00
    
      // --- insert ---
      timePeriods.Insert( 2, new TimeBlock( now, Duration.Minutes( 45 ) ) );
      Console.WriteLine( "TimePeriodChain.Insert(): " + timePeriods );
      // > TimePeriodChain.Insert(): Count = 4; 23.07.2010 08:00:00 - 13:15:00 | 0.05:15
      foreach ( ITimePeriod timePeriod in timePeriods )
      {
        Console.WriteLine( "Item: " + timePeriod );
      }
      // > Item: 23.07.2010 08:00:00 - 10:00:00 | 02:00:00
      // > Item: 23.07.2010 10:00:00 - 11:30:00 | 01:30:00
      // > Item: 23.07.2010 11:30:00 - 12:15:00 | 00:45:00
      // > Item: 23.07.2010 12:15:00 - 13:15:00 | 01:00:00
    } // TimePeriodChainSample
