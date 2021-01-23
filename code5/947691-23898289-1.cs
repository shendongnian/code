    public decimal MeanForParticularDate( DateTime desired , Dictionary<DateTime,int>[] collection )
    {
      decimal n   = 0 ;
      decimal sum = 0 ;
      
      foreach( Dictionary<DateTime,int> dict in collection )
      {
        int value ;
        bool found = dict.TryGetValue( desired , out value ) ;
        
        if ( !found ) continue ;
        ++n ;
        sum += value ;
        
      }
      
      decimal mean = sum/n ;
      return mean ;
    }
