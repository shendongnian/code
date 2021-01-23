    public ValidationOutput PerformMatch(IEnumerable<Int32?> values, decimal maximum)
    {
        return PerformMatch(values.Select(i => (decimal?)i), maximum);
    }
    public ValidationOutput PerformMatch(IEnumerable<Int64?> values, decimal maximum)
    {
        return PerformMatch(values.Select(i => (decimal?)i), maximum);
    }
    public ValidationOutput PerformMatch(IEnumerable<decimal?> values, decimal maximum)
    {
        // your logic here
    }
