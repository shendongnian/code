    public static IEnumerable<Tuple<TIn, int>> MarkWithLabels<TIn>(this IEnumerable<TIn> src, Predicate<TIn> splittingCondition)
    {
        int label = 0;
        foreach (TIn item in src)
        {
            yield return new Tuple<TIn, int>(item, label);
            if (splittingCondition(item))
                label++;
        }
    }
