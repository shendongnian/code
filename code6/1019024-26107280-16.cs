    private static Expression<Func<Site, ContactPointExt<T>>> GetContactPoints<T>(ParameterExpression siteParam, ParameterExpression cpeParam)
    {
        var type = typeof(ContactPointExt<T>);
        var newExp = Expression.New(type);
        var initExp = Expression.MemberInit(
            newExp,
            Expression.Bind(type.GetProperty("Instance"), siteParam),
            Expression.Bind(type.GetProperty("Email"), GetContactPoint(siteParam, cpeParam, ContactPointType.Email).Body),
            Expression.Bind(type.GetProperty("Phone"), GetContactPoint(siteParam, cpeParam, ContactPointType.Phone).Body)
        );
        var selector = Expression.Lambda<Func<Site, ContactPointExt<T>>>(initExp, siteParam);
        return selector;
    }
