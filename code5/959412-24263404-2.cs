    MyList = InputFile.AsParallel()
                      .SelectMany(row => row.AsParallel()
                                            .Select(cell => TransformCell(c.Value));
    public string TransformCell(string value)
    {
       return value + " something";
    }
