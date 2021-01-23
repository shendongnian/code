    public static IQueryable<T> Match<T>(this IQueryable<T> data, string searchTerm,
                                             params Expression<Func<T, string>>[] filterProperties)
    {
        var parameter = Expression.Parameter(typeof (T), "source");
        Expression body = null;
        
        foreach (var prop in filterProperties)
        {
            // need to replace all the expressions with the one parameter (gist taken from Colin Meek blog see link on top of class)
            //prop.body should be the member expression
            var propValue =
                prop.Body.ReplaceParameters(new Dictionary<ParameterExpression, ParameterExpression>()
                    {
                        {prop.Parameters[0], parameter}
                    });
           
            // is null check
            var isNull = Expression.NotEqual(propValue, Expression.Constant(null, typeof(string)));
            
            // create a tuple so EF will parameterize the sql call
            var searchTuple = Tuple.Create(searchTerm);
            var matchTerm = Expression.Property(Expression.Constant(searchTuple), "Item1");
            // call ToUpper
            var toUpper = Expression.Call(propValue, "ToUpper", null);
            // Call contains on the ToUpper
            var contains = Expression.Call(toUpper, "Contains", null, matchTerm);
            // And not null and contains
            var and = Expression.AndAlso(isNull, contains);
            // or in any additional properties
            body = body == null ? and : Expression.OrElse(body, and);
        }
        if (body != null)
        {
            var where = Expression.Call(typeof (Queryable), "Where", new[] {typeof (T)}, data.Expression,
                                        Expression.Lambda<Func<T, bool>>(body, parameter));
            return data.Provider.CreateQuery<T>(where);
        }
        return data;
    }
     public static Expression ReplaceParameters(this Expression exp, IDictionary<ParameterExpression, ParameterExpression> map)
    {
        return new ParameterRebinder(map).Visit(exp);
    }
