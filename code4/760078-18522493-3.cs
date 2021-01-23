    public DateTime MsDateToDateTime( string msDate )
    {
      int daysSinceEpoch ;
      bool parsed = int.TryParse( msDate , out daySinceEpoch ) ;
      if ( !parsed ) throw new ArgumentException("msDate") ;
      
      Datetime value = epoch.AddDays( daysSinceEpoch ) ;
      return value ;
    }
    // our epoch is 1 January 1900 00:00:00
    private static readonly DateTime epoch = new DateTime(1900,1,1) ;
