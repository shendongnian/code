        public bool isValid( string s )
        {
          bool valid = true ;
          for ( int i = 0 ; valid  && i < s.Length ; ++i )
          {
            char c = s[i] ;
            valid = c == ' ' || ( c >= 'a' && c <= 'z' ) || ( c >= 'A' && c <= 'Z' ) ;
          }
            return valid ;
        }
