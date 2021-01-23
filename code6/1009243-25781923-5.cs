    try
    {
        throw new Exception("1", new Exception("2", new Exception("3", new Exception("4"))));
    }
    catch (Exception ex)
    {
        foreach (var ie in ex.EnumerateInnerExceptions())
        {
            Console.WriteLine(ie.Message);
        }
    }
