    public int CommonChars(string left, string right)
    {
        return left.GroupBy(c => c)
            .Join(
                right.GroupBy(c => c),
                g => g.Key,
                g => g.Key,
                (lg, rg) => Math.Min(lg.Count(), rg.Count()))
            .Sum(); 
    }
