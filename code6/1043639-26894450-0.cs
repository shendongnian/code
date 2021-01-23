    List<ResultProperties> a = LoadSourceList() ;
    
    IEnumerable<IGrouping<string,ResultProperties> groups =
      a
      .GroupBy( x => x.TestCaseName , StringComparer.OrdinalIgnoreCase )
      ;
    
    List<ResultProperties> coalesced = new List<ResultProperties>() ;
    foreach( IGrouping<string,ResultProperties> group in groups )
    {
      ResultProperties item = null ;
      foreach( ResultProperty rp in group )
      {
        item          = item          ?? rp          ;
        item.Screen   = item.Screen   ?? rp.Screen   ;
        item.IEStatus = item.IEStatus ?? rp.IEStatus ;
        item.IEPath   = item.IEPath   ?? rp.IEPath   ;
        item.FFStatus = item.FFStatus ?? rp.FFStatus ;
        item.FFPath   = item.FFPath   ?? rp.FFPath   ;
        item.GCStatus = item.GCStatus ?? rp.GCStatus ;
        item.GCPath   = item.GCPath   ?? rp.GCPath   ;
      }
      coalesced.Add(item) ;
    }
