    class StringCleaner
    {
      private Regex regex ;
      
      public StringCleaner( string invalidChars ) : this ( (IEnumerable<char>) invalidChars )
      {
        return ;
      }
      public StringCleaner ( params char[] invalidChars ) : this( (IEnumerable<char>) invalidChars )
      {
        return ;
      }
      public StringCleaner( IEnumerable<char> invalidChars )
      {
        const string    HEX     = "0123456789ABCDEF" ;
        SortedSet<char> charSet = new SortedSet<char>( invalidChars ) ;
        StringBuilder   sb      = new StringBuilder( 2 + 6*charset.Count ) ;
        
        sb.Append('[') ;
        foreach ( ushort c in charSet )
        {
          sb.Append(@"\u" )
            .Append( HEX[ ( c >> 12 ) & 0x000F ] )
            .Append( HEX[ ( c >>  8 ) & 0x000F ] )
            .Append( HEX[ ( c >>  4 ) & 0x000F ] )
            .Append( HEX[ ( c >>  0 ) & 0x000F ] )
            ;
        }
        sb.Append(']') ;
        this.regex = new Regex( sb.ToString() ) ;
      }
      public string Clean( string s )
      {
        if ( string.IsNullOrEmpty(s) ) return s ;
        string value = this.regex.Replace(s,"") ;
        return value ;
      }
        
    }
