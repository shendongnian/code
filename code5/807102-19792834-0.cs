    static void AddCustomerPredicate(
        List<Expression<Func<Customer, bool>>> predicates,
        Expression<Func<Customer, string>> prop,
        string searchString)
    {
        var memberAccess = prop.Body as MemberExpression;
        if (memberAccess == null)
            throw new ArgumentException("Expression must be a member access.");
        var x = Expression.Parameter(typeof(Customer), "x");
        var temp = Expression.Variable(typeof(string), "temp");
        var predicate = Expression.Lambda<Func<Customer, bool>>(
            Expression.Block(
                new[] { temp },
                Expression.Assign(
                    temp,
                    Expression.MakeMemberAccess(x, memberAccess.Member)),
                Expression.AndAlso(
                    Expression.IsFalse(
                        Expression.ReferenceEqual(
                            temp,
                            Expression.Default(typeof(string)))),
                    Expression.Call(
                        temp,
                        "Contains",
                        Type.EmptyTypes,
                        Expression.Constant(searchString)))),
            x);
        predicates.Add(predicate);
    }
