    public static IEnumerable<IEnumerable<T>> SubsetsAddingUpTo(this IEnumerable<T> source, int target)
    {
        // This stopping condition ensures that you will not have to walk the tree when you have already hit your target.
        // It assumes that the Number values are all non-negative.
        if (target < 0) return Enumerable.Empty<IEnumerable<T>>();
        var first = source.FirstOrDefault();
        if (first == null) return Enumerable.Empty<IEnumerable<T>>();
        var targetMinusFirstNumber = target - first.Number;
        var tail = source.Skip(1).ToList();
        var othersIncludingFirst = tail.Where(i => i.Number <= targetMinusFirstNumber).SubsetsAddingUpTo(targetMinusFirstNumber);
        var othersExcludingFirst = tail.Where(i => i.Number <= target).SubsetsAddingUpTo(target);
        return othersExcludingFirst.Concat(othersIncludingFirst.Select(s => s.Concat(new { first })));
    }
