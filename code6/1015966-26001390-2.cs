    public static void ParseEach( this IEnumerable<T> string strings )
    {
      foreach ( string s in strings )
      {
         Parse(s) ;
      }
    }
