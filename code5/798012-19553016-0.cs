    class MyTransactions
    {
      private DateTime? OldestDate   { get ; set ; }
      private Dictionary<DateTime,List<Transaction>> BackingStore { get ; set ; }
      private int RetentionPeriodInDays
      {
        get
        {
          DateTime now     = DateTime.Now.Date ;
          TimeSpan oneYear = now - now.AddYears(-1) ;
          int      days    = (int) oneYear.TotalDays ;
          return days ;
        }
      }
      
      public MyTransactions()
      {
        OldestDate = null ;
        BackingStore = new Dictionary<DateTime,List<Transaction>>();
      }
      
      public void Add( Transaction t )
      {
        if ( t == null ) throw new ArgumentNullException("t");
        
        if ( this.BackingStore.Count > RetentionPeriodInDays )
        {
          this.BackingStore.Remove(this.OldestDate.Value ) ;
          this.OldestDate = this.BackingStore.Keys.Min() ;
        }
        
        DateTime today = DateTime.Now.Date ;
        List<Transaction> transactions ;
        bool exists = this.BackingStore.TryGetValue(today,out transactions) ;
        if ( !exists )
        {
          transactions = new List<Transaction>();
          this.BackingStore.Add(today,transactions) ;
        }
        transactions.Add(t) ;
        
        if ( today < this.OldestDate )
        {
          this.OldestDate = today ;
        }
        
        return ;
      }
      public List<Transaction> TodaysData
      {
        get
        {
          DateTime today = DateTime.Now.Date ;
          List<Transaction> value = new List<Transaction>( this.BackingStore[today] ) ;
          return value ;
        }
      }
      
      public List<Transaction> CurrentWeekData
      {
        get
        {
          DateTime today = DateTime.Now.Date ;
          List<Transaction> value = this.BackingStore
                                        .Where( x => x.Key > today.AddDays(-7) )
                                        .SelectMany( x => x.Value )
                                        .ToList()
                                        ;
          return value ;
        }
      }
    }
