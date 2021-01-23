    //ReadOne 1
    T Read(int id);
    //ReadOne 2
    T Read(params object[] keyValues);
    //ReadOne 3
    T Read(SinglePredicateExpression<T> predicate);
    //Search
    IQueryable<T> Read(MultiPredicateExpression<T> predicate);
    IQueryable<T> Read();
