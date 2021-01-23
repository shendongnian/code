    public static string StripNonDigits( string s )
    {
      return new StringBuilder(s.Length)
             .Append( s.Where(char.IsDigit).ToArray() )
             .ToString()
             ;
    }
