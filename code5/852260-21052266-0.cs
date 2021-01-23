    string cacheID = "myCacheID"; 
    DataTable data = null;
    if (HttpContext.Current.Cache[cacheID] == null)
    {
      data = GetThatHugeDataTable();
      HttpContext.Current.Cache.Insert(cacheID, data);
    }
    else
    {
      data = (DataTable)HttpContext.Current.Cache[cacheID];
    }
