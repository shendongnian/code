    public static IQueryable<T> Foo<T>(
        this IQueryable<T> query)
        where T : IHasCostCenter
    {
        var validIDs = User.CostCenters.Select(cc => cc.CostCenterId);
        return query.Where(item => validIDs.Contains(item.CostCenterId));
    }
