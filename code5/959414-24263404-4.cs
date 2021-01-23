    MyList = InputFile.AsParallel()
                      .SelectMany(row => row.AsParallel()
                                            .Select(cell => TransformCell(c.Value))
                      .ToList();
    public string TransformCell(string value)
    {
       return value + " something";
    }
