    MyList = InputFile.AsParallel()
                      .SelectMany(row => row.AsParallel()
                                            .Select(cell => TransformCell(cell.Value))
                      .ToList();
    public string TransformCell(string value)
    {
       return value + " something";
    }
