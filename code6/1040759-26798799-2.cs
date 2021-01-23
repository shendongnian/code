    public void DoSomething(params object[] values)
    {
        foreach (dynamic value in values)
        {
            // Overload resolution will be performed at execution time
            DoSomethingImpl(value);
        }
    }
    private void DoSomethingImpl(double value) { ... }
    private void DoSomethingImpl(double[] value) { ... }
