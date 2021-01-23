    public static IQueryable<T> Foo<T>(
        this IQueryable<T> query,
        Expression<Func<T, IHasCostCenter>> selector)
    {
        var validIDs = User.CostCenters.Select(cc => cc.CostCenterId);
        return query.Where(selector.Compose(
            item => validIDs.Contains(item.CostCenterId)));
    }
