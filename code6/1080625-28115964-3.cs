    public TablesProvider()
    {
        var GenericParameters = new[] { typeof(string), typeof(int), typeof(DateTime) };
        _tables = new MyList[GenericParameters.Length];
        for (int i = 0; i < GenericParameters.Length; i++)
        {
            _tables[i] = MakeList(GenericParameters[i]);
        }
    }
