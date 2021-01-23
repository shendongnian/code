    public bool IsPalindrome( string s )
    {
      bool isPalindrome = true ;
      int i = 0 ;
      int j = s.Length ;
      while ( j > i && isPalindrome )
      {
        isPalindrome = s[i++] == s[--j] ;
      }
      return isPalindrome ;
    }
