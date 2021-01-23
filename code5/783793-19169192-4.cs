    * You could use LINQ directly, since a string is an `IEnumerable<char>`:
    
            private string CleanStringOfNonDigits_V4( string s )
            {
              if ( string.IsNullOrEmpty(s) ) return s;
              string cleaned = new string( s.Where( char.IsDigit ).ToArray() ) ;
              return cleaned;
            }
    * If you're only dealing with western alphabets where the only decimal digits you'll see are ASCII, skipping `char.IsDigit` will likely buy you a little performance:
            private string CleanStringOfNonDigits_V5( string s )
            {
              if (string.IsNullOrEmpty(s)) return s;
              string cleaned = new string(s.Where( c => c-'0' < 10 ).ToArray() ) ;
              return cleaned;
            }
