    public void DoSomething(params object[] values)
    {
        foreach (object value in values)
        {
            if (value is double)
            {
                DoSomethingImpl((double) value);
                // Or: DoSomethingImpl(new[] { (double) value });
            }
            else if (value is double[])
            {
                DoSomethingImpl((double[]) value);
            }
            ...
        }
    }
