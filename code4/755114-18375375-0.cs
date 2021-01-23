    Dictionary<string, Func<decimal, decimal>> func1;
    Dictionary<string, Func<decimal, decimal, decimal>> func2;
    public void AddFunction (Func<decimal, decimal> f, string name)
    {
        func1.Add(name, f);
    }
    public void AddFunction (Func<decimal, decimal, decimal> f, string name)
    {
        func2.Add(name, f);
    } 
    public decimal PerformOperation (string op, decimal x)
    {
        return func1[op](x);
    }
    public decimal PerformOperation (string op, decimal x, decimal y)
    {
        return func2[op](x, y);
    }
