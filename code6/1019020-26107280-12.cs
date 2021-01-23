    private static Expression<Func<Site, string>> GetContactPoint(ParameterExpression siteParam, ParameterExpression cpeParam, ContactPointType type)
    {
        // Where.
        var typeCondition = Expression.Equal(Expression.Property(cpeParam, "Type"), Expression.Constant(type));
        var defaultCondition = Expression.Equal(Expression.Property(cpeParam, "IsDefault"), Expression.Constant(true));
        var condition = Expression.AndAlso(typeCondition, defaultCondition);
        var predicateExp = Expression.Lambda<Func<ContactPointEntity, bool>>(condition, cpeParam);
        var whereExp = Expression.Call(typeof(Enumerable), "Where", new[] { typeof(ContactPointEntity) }, Expression.Property(siteParam, "ContactPoints"), predicateExp);
        // Select.
        var valueExp = Expression.Lambda<Func<ContactPointEntity, string>>(Expression.Property(cpeParam, "Value"), cpeParam);
        var selectExp = Expression.Call(typeof(Enumerable), "Select", new[] { typeof(ContactPointEntity), typeof(string) }, whereExp, valueExp);
        // DefaultIfEmpty.
        var defaultIfEmptyExp = Expression.Call(typeof(Enumerable), "DefaultIfEmpty", new[] { typeof(string) }, selectExp, Expression.Constant(string.Empty));
        // FirstOrDefault.
        var firstOrDefaultExp = Expression.Call(typeof(Enumerable), "FirstOrDefault", new[] { typeof(string) }, defaultIfEmptyExp);
        var selector = Expression.Lambda<Func<Site, string>>(firstOrDefaultExp, siteParam);
        return selector;
    }
