    public IEnumerable<string> GetOrderCombinations( string me )
    {
      int l = me.Length ;
      string looped = me + me ;
      
      for ( int start = 0 ; start < l ; ++start )
      {
        for ( int length = 1 ; length < l ; ++length )
        {
          yield return looped.Substring(start,length) ;
        }
      }
      
    }
