    public static double Quartile(this IOrderedEnumerable<double> list,
                                  Func<double,double,bool> predicate)
    {
        var median = list.Median();
        var elements = list.Where(x=>predicate(x,median)).ToList();
        if (!list.Contains(median))
            elements.Add(median);
        return elements.OrderBy(x => x).Median();
    }
