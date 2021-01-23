    public static double StandardDeviation(this ICollection<double> values)
    {
        return Math.Sqrt(values.Variance());
    }
    public static double Variance(this ICollection<double> values)
    {
        if (values.Count == 0)
            return 0;
        var avg = values.Average();
        return values.Select(x => Math.Pow(x - avg, 2)).Sum() / values.Count;
    }
