    public static string StripWhitespace( string s )
    {
      char[] buf = s.ToCharArray() ;
      int j = 0 ; // target pointer
      for ( int i = 0 ; i < buf.Length ; ++i )
      {
        char c = buf[i] ;
        if ( !IsWs(c) )
        {
          buf[j++] = c ;
        }
      }
      string stripped = new string(buf,0,j) ;
      return stripped ;
    }
    
    private static bool IsWs( char c )
    {
      bool ws = false ;
      switch ( c )
      {
    //case '\b' : // U+0008, BS uncomment if you want BS as whitespace
      case '\t' : // U+0009, HT
      case '\n' : // U+000A, LF
      case '\v' : // U+000B, VT
      case '\f' : // U+000C, FF
      case '\r' : // U+000D, CR
      case ' '  : // U+0020, SP
        ws = true ;
        break ;
      }
      return ws ;
    }
