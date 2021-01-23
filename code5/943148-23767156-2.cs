    class TimeStamp
    {
      static readonly DateTime  unixEpoch        = new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc) ;
      static readonly long      BaseMicroseconds = (DateTime.UtcNow-unixEpoch).Ticks / 10L ;
      static readonly Stopwatch Stopwatch        = Stopwatch.StartNew() ;
      static          long      State            = TimeSpan.MinValue.Ticks ;
      
      private long OffsetInMicroseconds ;
      
      private TimeStamp()
      {
        long oldState ;
        long newState ;
        
        do
        {
          oldState = State ;
          newState = Stopwatch.Elapsed.Ticks / 10L ;
        } while (    oldState == newState
                  || oldState != Interlocked.CompareExchange( ref State , newState , oldState )
                ) ;
        
        this.OffsetInMicroseconds = newState ;
        return ;
      }
      
      public static TimeStamp GetNext()
      {
        return new TimeStamp() ;
      }
      
      public override string ToString()
      {
        long   v = BaseMicroseconds + this.OffsetInMicroseconds ;
        string s = v.ToString() ; // conversion to Base 36 not implemented ;
        return s ;
      }
      
    }
