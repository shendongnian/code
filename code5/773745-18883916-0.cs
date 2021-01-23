    static Regex rxNonDigits = new Regex( @"[^\d]+");
    public static string StripNonDigits( string s )
    {
      return rxNonDigits.Replace(s,"") ;
    }
