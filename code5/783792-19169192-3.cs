    * A negative character class that defines the characters that are what you don't want (those characters other than decimal digits):
            private static readonly Regex rxNonDigits = new Regex( @"[^\d]+");
        In which case, you can do take either of these approaches:
            // simply replace the offending substrings with an empty string
            private string CleanStringOfNonDigits_V1( string s )
            {
              if ( string.IsNullOrEmpty(s) ) return s ;
              string cleaned = rxNonDigits.Replace(s, "") ;
              return cleaned ;
            }
            // split the string into an array of good substrings
            // using the bad substrings as the delimiter. Then use
            // String.Join() to splice things back together.
            private string CleanStringOfNonDigits_V2( string s )
            {
              if (string.IsNullOrEmpty(s)) return s;
              string cleaned = String.Join( rxNonDigits.Split(s) );
              return cleaned ;
            }
    * a positive character set that defines what you do want (decimal digits):
            private static Regex rxDigits = new Regex( @"[\d]+") ;
        In which case you can do something like this:
            private string CleanStringOfNonDigits_V3( string s )
            {
              if ( string.IsNullOrEmpty(s) ) return s ;
              StringBuilder sb = new StringBuilder() ;
              for ( Match m = rxDigits.Match(s) ; m.Success ; m = m.NextMatch() )
              {
                sb.Append(m.Value) ;
              }
              string cleaned = sb.ToString() ;
              return cleaned ;
            }
