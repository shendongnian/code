    public static int EnsurePageNo(
                            this int page, 
                            int pageSize, 
                            int totalItems)
    {
        if (pageSize < 1) 
             throw new ArgumentException("Page size should at least 1.", "pageSize");
        if (page < 1) return 1;
        
        return page > totalItems / pageSize 
                    ? totalItems / pageSize + 1;
                    : page;
    }
    public static IEnumerable<T> Page<T>(
                    this IEnumerable<T> source, 
                    int page, 
                    int pageSize)
    {
        var toSkip = pageSize * page;
        var take = pageSize;
    
        return source.Skip(toSkip).Take(take);
    }
    public static IEnumerable<T> SafePage<T>(
                      this IEnumerable<T> source, 
                      int page, 
                      int? pageSize, 
                      int totalItems)
    {
        // no paging
        if (!pageSize.HasValue) return source;
    
        if (page < 1)
            throw new ArgumentException("Page number should be greater or equal 1.");
    
        var pgSize = pageSize.Value;
        page = page.EnsurePageNo(pgSize, totalItems);
        return source.Page(page - 1, pgSize);
    }
