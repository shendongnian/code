    private static Expression<Func<UserProfile, bool>> 
        Predicate(FilterViewModel f)
    {
       return CompareFilter(f));
    }
    private static Expression<Func<UserProfile, bool>>
        CompareFilter(FilterViewModel filter)
    {
        if (filter.FirstName != null)
        {
            if (profile.FirstName != null)
            {
                return p => p.FirstName == filter.FirstName;
            }
       ...
       // this means nothing to compare, 
       // return all records...
       return p => true;
    }
