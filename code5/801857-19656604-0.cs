    IQueryable myQuery = ... your query you want to filter ...;
    string searchWhat = "text to search";
    bool startsWith;
    Expression condition = null;
    var p = Expression.Parameter(myQuery.ElementType,"x");
    foreach (string column in columnsToSearch)
    {
        if (startsWith)
        {
            var myCondition = Expression.Call(Expression.PropertyOrField(p, column),
                              typeof (string).GetMethod("StartsWith"),
                              Expression.Constant(searchWhat));
            if (condition == null)
                condition = myCondition;
            else
                condition = Expression.OrElse(condition, myCondition);
         }
     }
     var newQuery = Expression.Call(typeof (Queryable).GetMethod("Where"), myQuery.Expression, Expression.Lambda(condition, p));
     var myQueryFiltered = myQuery.Provider.CreateQuery(newQuery);
