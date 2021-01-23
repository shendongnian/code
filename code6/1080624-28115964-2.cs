    public TablesProvider()
    {
        var GenericParameters = new[] { typeof(string), typeof(int), typeof(DateTime) };
    
        _tables = GenericParameters.Select(MakeList).ToArray();
    }
