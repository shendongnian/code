        private string CleanStringOfNonDigits_V6( string s )
        {
          if (string.IsNullOrEmpty(s)) return s;
          StringBuilder sb = new StringBuilder(s.Length) ;
          for (int i = 0; i < s.Length; ++i)
          {
            char c = s[i];
            if ( c < '0' ) continue ;
            if ( c > '9' ) continue ;
            sb.Append(s[i]);
          }
          string cleaned = sb.ToString();
          return cleaned;
        }
    Or this:
        private string CleanStringOfNonDigits_V7(string s)
        {
          if (string.IsNullOrEmpty(s)) return s;
          StringBuilder sb = new StringBuilder(s);
          int j = 0 ;
          int i = 0 ;
          while ( i < sb.Length )
          {
            bool isDigit = char.IsDigit( sb[i] ) ;
            if ( isDigit )
            {
              sb[j++] = sb[i++];
            }
            else
            {
              ++i ;
            }
          }
          sb.Length = j;
          string cleaned = sb.ToString();
          return cleaned;
        }
