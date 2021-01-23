    static IEnumerable<string> SliceAndDice1( string s , int n )
    {
      if ( s == null ) throw new ArgumentNullException("s");
      if ( n < 1 ) throw new ArgumentOutOfRangeException("n");
      int i = 0 ;
      return s.GroupBy( c => i++ / n ).Select( g => g.Aggregate(new StringBuilder() , (sb,c)=>sb.Append(c)).ToString() ) ;
    }
