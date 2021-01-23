    public static class StringHelpers
    {
      public static string StripWhitespace( this string s )
      {
        StringBuilder sb = new StringBuilder() ;
        foreach ( char c in s )
        {
          switch ( c )
          {
        //case '\b' : continue ; // U+0008, BS uncomment if you want this
          case '\t' : continue ; // U+0009, HT
          case '\n' : continue ; // U+000A, LF
          case '\v' : continue ; // U+000B, VT
          case '\f' : continue ; // U+000C, FF
          case '\r' : continue ; // U+000D, CR
          case ' '  : continue ; // U+0020, SP
          }
          sb.Append(c) ;
        }
        string stripped = sb.ToString() ;
        return stripped ;
      }
    }
