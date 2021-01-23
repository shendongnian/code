    var subquery = session.QueryOver<T>(); // it is named subquery
    // but it is not of a type QueryOver<T>, but of a type
    // IQueryOver<T, T>
    // which is not what is expected here
     var query = QueryOver.Of<Table1>()
                .WithSubquery
                   .WhereProperty(t1 => t1.foreign_key)
                   // won't compile, because passed is IQueryOver<T,T>, 
                   // not the QueryOver<U>   
                   .In(subquery)
                ...
