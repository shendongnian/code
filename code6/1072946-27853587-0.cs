    public static T MatchedOrFirstOrDefault<T>(this IQueryable<T> collection, System.Linq.Expressions.Expression<Func<T, Boolean>> predicate)
    {
      return (from item in collection.Where(predicate) select item)
                        .Concat((from item in collection select item).Take(1))
                        .ToList() // Convert to query result
                        .FirstOrDefault();
    }
