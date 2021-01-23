    public List<Q> GetPagedData<T, Q>(int startindex, int pagesize, string sorting, Func<T, Q> selector = null)
    {
        dynamic pageddata = dbset;
        pageddata = pageddata.OrderBy(sorting).Skip(startindex).Take(pagesize);
        return pageddata.Select(selector).ToList();
    }
