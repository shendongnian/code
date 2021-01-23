    public static IList<EmployeeObject> QLike(Expression<Func<EmployeeObject, bool>> func)
    {
        var queryable = QueryableSQL().Where(func);
        return queryable.ToList();
    }
