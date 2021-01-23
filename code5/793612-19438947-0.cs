    class MyResourceIntensiveTimer : IDisposable
    {
      private Stopwatch Stopwatch     ;
      private Timer     Timer         ;
      private long      PrevTick      ;
      private long      PeriodInTicks ;
      
      public Decimal TicksToNextTock
      {
        get
        {
          long elapsedTicks = Stopwatch.ElapsedTicks - PrevTick ;
          decimal value = ((decimal)elapsedTicks) / ((decimal)this.PeriodInTicks) ;
          return value ;
        }
      }
      
      public MyResourceIntensiveTimer( TimeSpan period )
      {
        if ( period <= TimeSpan.Zero ) throw new ArgumentOutOfRangeException("period") ;
        this.PeriodInTicks = period.Ticks ;
        this.Timer    = new Timer( TimerCallback , null , period , period ) ;
        this.PrevTick = (this.Stopwatch=Stopwatch.StartNew()).ElapsedTicks ;
        return ;
      }
      
      private void TimerCallback( object o )
      {
        this.PrevTick = Stopwatch.ElapsedTicks ;
        this.OnTock.Invoke() ;
        return ;
      }
      
      public event Action OnTock ;
      
      public void Dispose()
      {
        
        if ( this.Stopwatch != null )
        {
          if ( this.Stopwatch.IsRunning )
          {
            this.Stopwatch.Stop() ;
          }
          this.Stopwatch = null ;
        }
        
        if ( this.Timer != null )
        {
          this.Timer.Change(Timeout.Infinite , Timeout.Infinite ) ; // shut things down
          this.Timer = null ;
        }
        
      }
    }
