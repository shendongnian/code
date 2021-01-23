    public static Dictionary<TKey,TValue> Extend<TKey,TValue>( params Dictionary<TKey,TValue>[] sources )
    {
      return Extend<TKey,TValue>( null , sources ) ;
    }
    public static Dictionary<TKey,TValue> Extend<TKey,TValue>( IEqualityComparer<TKey> comparer , params Dictionary<TKey,TValue>[] sources )
    {
      return sources
             .SelectMany( kvp => kvp )
             .GroupBy( kvp => kvp.Key , kvp => kvp.Value , comparer )
             .ToDictionary( grp => grp.Key , grp => grp.Last() , comparer )
             ;
    }
