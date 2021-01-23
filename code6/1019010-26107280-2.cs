    private static Expression<Func<Site, SiteLabelDto>> GetSite(ParameterExpression siteParam, ParameterExpression cpeParam)
    {
        var newExp = Expression.New(typeof(SiteLabelDto));
        var initExp = Expression.MemberInit(
            newExp,
            Expression.Bind(typeof(SiteLabelDto).GetProperty("Id"), Expression.Lambda<Func<Site, int>>(Expression.Property(siteParam, "Id"), siteParam).Body),
            Expression.Bind(typeof(SiteLabelDto).GetProperty("Name"), Expression.Lambda<Func<Site, string>>(Expression.Property(siteParam, "Name"), siteParam).Body),
            /* other basic information */
            Expression.Bind(typeof(SiteLabelDto).GetProperty("Email"), GetContactPoint(siteParam, cpeParam, ContactPointType.Email).Body),
            Expression.Bind(typeof(SiteLabelDto).GetProperty("Phone"), GetContactPoint(siteParam, cpeParam, ContactPointType.Phone).Body)
            /* other types */
        );
        var selector = Expression.Lambda<Func<Site, SiteLabelDto>>(initExp, siteParam);
        return selector;
    }
