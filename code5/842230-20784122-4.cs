    public static Expression<Func<Person, bool>> BuildFilter(IFilter filter)
    {
        var param = Expression.Parameter(typeof(Person), "p");
        List<Expression> conditions = new List<Expression>();
        foreach (var p in filter.GetType().GetProperties())
        {
            if (p.GetValue(filter) != null)
            {
                Attribute filterAttribute
                    = p.GetCustomAttributes(
                        typeof(FilterElementAttribute),
                        false).SingleOrDefault() as Attribute;
                if (filterAttribute == null)
                {
                    continue; // throw internal error
                }
                var expressionType = ((FilterElementAttribute)filterAttribute)
                    .ExpressionType;
                conditions.Add(
                    Expression.MakeBinary(expressionType,
                                          Expression.Property(param, p.Name),
                                          Expression.Constant(p.GetValue(filter))));
            }
        }
        return Expression.Lambda<Func<Person, bool>>(
            conditions.Aggregate((e1, e2) => Expression.And(e1, e2)),
            param);
    }
