    public static int NotIndexOf( this string s , string chars )
    {
      char[] orderedChars = chars.ToCharArray() ;
      Array.Sort( orderedChars ) ;
      
      int index = -1 ;
      for ( int i = 0 ; index < 0 && i < s.Length ; ++i )
      {
        int p = Array.BinarySearch(orderedChars, s[i] ) ;
        if ( p < 0 )
        {
          index = i ;
        }
      }
      return index ;
    }
