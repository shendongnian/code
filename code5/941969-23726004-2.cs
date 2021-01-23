    try
    {
        var processor = new FileProcessor();
        processor.Run();
    }
    catch (RijException exception)
    {
        Console.WriteLine(exception.StackTrace);
    }
