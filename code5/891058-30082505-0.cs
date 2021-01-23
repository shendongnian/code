    public static class QueryableExtensions
    {
        public static IQueryable<T> TopWithTies<T, TComparand>(this IQueryable<T> source, Expression<Func<T, TComparand>> topBy, int topCount)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (topBy == null) throw new ArgumentNullException("topBy");
            if (topCount < 1) throw new ArgumentOutOfRangeException("topCount", string.Format("topCount must be greater than 0, was {0}", topCount));
            var topValues = source.OrderBy(topBy)
                                  .Select(topBy)
                                  .Take(topCount);
            var queryableMaxMethod = typeof(Queryable).GetMethods()
                                                      .Single(mi => mi.Name == "Max" &&
                                                                    mi.GetParameters().Length == 1 &&
                                                                    mi.IsGenericMethod)
                                                      .MakeGenericMethod(typeof(TComparand));
            var lessThanOrEqualToMaxTopValue = Expression.Lambda<Func<T, bool>>(
                Expression.LessThanOrEqual(
                    topBy.Body,
                    Expression.Call(
                        queryableMaxMethod,
                        topValues.Expression)),
                new[] { topBy.Parameters.Single() });
            var topNRowsWithTies = source.Where(lessThanOrEqualToMaxTopValue)
                                         .OrderBy(topBy);
            return topNRowsWithTies;
        }
        public static IQueryable<T> TopWithTiesDescending<T, TComparand>(this IQueryable<T> source, Expression<Func<T, TComparand>> topBy, int topCount)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (topBy == null) throw new ArgumentNullException("topBy");
            if (topCount < 1) throw new ArgumentOutOfRangeException("topCount", string.Format("topCount must be greater than 0, was {0}", topCount));
            var topValues = source.OrderByDescending(topBy)
                                  .Select(topBy)
                                  .Take(topCount);
            var queryableMinMethod = typeof(Queryable).GetMethods()
                                                      .Single(mi => mi.Name == "Min" &&
                                                                    mi.GetParameters().Length == 1 &&
                                                                    mi.IsGenericMethod)
                                                      .MakeGenericMethod(typeof(TComparand));
            var greaterThanOrEqualToMinTopValue = Expression.Lambda<Func<T, bool>>(
                Expression.GreaterThanOrEqual(
                    topBy.Body,
                    Expression.Call(queryableMinMethod,
                                    topValues.Expression)),
                new[] { topBy.Parameters.Single() });
            var topNRowsWithTies = source.Where(greaterThanOrEqualToMinTopValue)
                                         .OrderByDescending(topBy);
            return topNRowsWithTies;
        }
    }
