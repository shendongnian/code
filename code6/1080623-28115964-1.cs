    public TablesProvider()
    {
        _tables = new MyList[45];
        var GenericParameters = new[] {typeof (string), typeof (int), typeof (DateTime)};
        for (int i = 0; i < types.Length; i++)
        {
            _tables[i] = MakeList(GenericParameters[i]);
        }
    }
