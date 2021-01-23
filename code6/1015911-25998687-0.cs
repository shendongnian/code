    public void Test(params Foo[] values)
    {
        var valuesAsInts = values.Select(x => (int)x);
        Test(valuesAsInts);
    }
