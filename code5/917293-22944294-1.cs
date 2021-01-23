    public void RemoveTrailingZeros( List<int> digits )
    {
      int i = digits.Count ;
      while ( --i >= 0 && digits[i] == 0 )
      {
        digits.RemoveAt(i) ;
      }
      return ;
    }
