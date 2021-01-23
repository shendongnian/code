    class TimeStamp
    {
      static readonly DateTime  Epoch        = DateTime.Now            ;
      static readonly Stopwatch Stopwatch    = Stopwatch.StartNew()    ;
      static          long      CurrentState = TimeSpan.MinValue.Ticks ;
      
      private TimeSpan Elapsed ;
      
      private TimeStamp()
      {
        long oldValue ;
        TimeSpan newValue ;
        
        do
        {
          oldValue = CurrentState      ; // save the current state in a local variable
          newValue = Stopwatch.Elapsed ; // get the new state
        }
        while ( oldValue != Interlocked.CompareExchange( ref CurrentState , newValue.Ticks , oldValue ) ) ;
        
        this.Elapsed = newValue ;
        
        return ;
      }
      
      public static TimeStamp GetNext()
      {
        return new TimeStamp() ;
      }
      
      public override string ToString()
      {
        DateTime instant = TimeStamp.Epoch + this.Elapsed ;
        string   s       = instant.ToString( "O" , CultureInfo.InvariantCulture ) ;
        return s ;
      }
      
    }
