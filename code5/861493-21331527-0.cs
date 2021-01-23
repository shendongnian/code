    public static IEnumerable<TEntity> EmptySetIfNull( this IEnumerable<TEntity> enumerable )
    {
        if( null == enumerable )
        {
            return new TEntity[] { };
        }
    
        return enumerable;
    } 
