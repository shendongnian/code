    public static IEnumerable<string> CsvSplit( this IEnumerable<char> text , char delimiter = ',' )
    {
      StringBuilder sb = new StringBuilder() ;
      foreach ( char c in text )
      {
        if ( c == delimiter )
        {
          yield return sb.ToString() ;
          sb.Length = 0 ;
        }
        else
        {
          sb.Append(c) ;
        }
      }
      if ( sb.Length > 0 )
      {
        yield return sb.ToString() ;
      }
    }
