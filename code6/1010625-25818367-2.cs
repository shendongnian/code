    static Regex CreateRegularExpressionFromTemplate( string template )
    {
      StringBuilder sb = new StringBuilder() ;
      
      foreach( char c in template )
      {
        if      ( char.IsLetter(      c ) ) sb.Append( @"\p{L}" ) ;
        else if ( char.IsNumber(      c ) ) sb.Append( @"\d"    ) ;
        else if ( char.IsWhiteSpace(  c ) ) sb.Append( @"\s"    ) ;
        else if ( char.IsPunctuation( c ) ) sb.Append( @"\p{P}" ) ;
        else throw new ArgumentOutOfRangeException("template") ;
      }
      
      string pattern = sb.ToString() ;
      Regex rx = new Regex( pattern ) ;
      return rx ;
    }
