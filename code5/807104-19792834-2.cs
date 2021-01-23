    private static void AddCustomerPredicate(
        List<Expression<Func<Customer, bool>>> predicates,
        Expression<Func<Customer, string>> accessor,
        string searchString)
    {
        var x = accessor.Parameters[0];
        var temp = Expression.Variable(typeof(string), "temp");
        var predicate = Expression.Lambda<Func<Customer, bool>>(
            Expression.Block(
                new[] { temp },
                Expression.Assign(
                    temp,
                    accessor.Body),
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
