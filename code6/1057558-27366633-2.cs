    public static IQueryable<T> Foo<T>(
        this IQueryable<T> query,
        Expression<Func<T, IEnumerable<IHasCostCenter>>> selector)
    {
        var validIDs = User.CostCenters.Select(cc => cc.CostCenterId);
        return query.Where(selector.Compose(list =>
            list.Any(item => validIDs.Contains(item.CostCenterId))));
    }
