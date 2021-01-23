    public static double EstimateAccuracy<T>(
        IEnumerable<IEnumerable<T>> actual
        , IEnumerable<IEnumerable<T>> estimate)
    {
        var query = actual.Zip(estimate, (a, b) => new
        {
            valid = a.Intersect(b).Count(),
            total = a.Count()
        }).ToList();
        return query.Sum(pair => pair.valid) /
            (double)query.Sum(pair => pair.total);
    }
