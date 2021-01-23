    static IEnumerable<Tuple<Double, Double>> GetGreatest(
        List<List<Tuple<double, double>>> list)
    {
        return list.Select(inner => inner.First())
            .GroupWhile((previous, current) => previous.Item2 == current.Item1)
            .Select(group => Tuple.Create(group.First().Item1, group.Last().Item2));
    }
