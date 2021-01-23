    private static IQueryable<UserProfile> 
        Predicate(IQueryable<UserProfile> q, FilterViewModel f)
    {
       
        if (filter.FirstName != null)
        {
            q = q.Where( p => p.FirstName == filter.FirstName );
        }
        if (filter.LastName != null)
        {
            q = q.Where( p => p.LastName == filter.LastName );
        }
       ...
       // return all records...
       return q;
    }
