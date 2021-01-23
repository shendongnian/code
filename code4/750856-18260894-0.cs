    public IEnumerable<T> GetList<TGroupKey, TOrderKey>(IEnumerable<T> collection, 
                                                        Func<T, TGroupKey> groupBy, 
                                                        Func<T, TOrderKey> orderBy, 
                                                        int howMany)
    {
        var group = collection
            .GroupBy(groupBy)
            .Select(x => x.OrderBy(orderBy).Take(howMany))
            .Aggregate((l1, l2) => l1.Concat(l2));
        return group.ToList();
    }
