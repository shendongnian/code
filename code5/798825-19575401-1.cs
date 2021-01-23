    static IEnumerable<string> SliceAndDice2( string s , int n )
    {
      if ( s == null ) throw new ArgumentNullException("s") ;
      if ( n < 1 ) throw new ArgumentOutOfRangeException("n") ;
      
      int i = 0 ;
      for ( i = 0 ; i < s.Length-n ; i+=n )
      {
        yield return s.Substring(i,n) ;
      }
      yield return s.Substring(i) ;
      
    }
