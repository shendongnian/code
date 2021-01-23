    public static IQueryable<T> Filter<T>(this IQueryable<T> source, SearchCriteria sc) 
        where T : class, IFilterable
    {
        var filtered = source.Where(e => e.Employee.CostCenterID == sc.CostCenterID 
            && e.Employee.Gender == sc.Gender);
         return filtered;
    }
