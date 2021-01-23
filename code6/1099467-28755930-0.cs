    public static Dictionary<TKey,TValue> Extend<TKey,TValue>( params Dictionary<TKey,TValue>[] sources )
    {
      return Extend<TKey,TValue>( null , sources ) ;
    }
    
    public static Dictionary<TKey,TValue> Extend<TKey,TValue>( IEqualityComparer<TKey> comparer , params Dictionary<TKey,TValue>[] sources )
    {
      var result = new Dictionary<TKey,TValue>( comparer ?? EqualityComparer<TKey>.Default ) ;
      
      foreach( var src in sources )
      {
        if ( src == null ) throw new ArgumentNullException("sources", "source dictionary may not be null");
        
        foreach( var item in src )
        {
          result[item.Key] = item.Value ;
        }
      }
      
      return result ;
    }
