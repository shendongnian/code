      public List<T> GetPagedData(int startindex, int pagesize, string sorting, Func<T, T>       
      selector = null)
     {
        var pageddata = dbset.OrderBy(sorting).Skip(startindex).Take(pagesize);
        if (selector != null)
           pageddata = pageddata.Select(selector).AsQueryable();
        return pageddata.ToList();
      }
