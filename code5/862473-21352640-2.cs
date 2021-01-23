    public static double CalculateQuartile(this IOrderedEnumerable<double> list,
            bool calculateUpperQuartile = false)
    {
        var median = list.Median();
        var predicate = calculateUpperQuartile ? (x => x > median) : (x => x < median);
        var elements = list.Where(predicate).ToList();
        if (!list.Contains(median))
            elements.Add(median);
        return elements.OrderBy(x => x).Median();
    }
