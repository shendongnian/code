    try
    {
        DoSomething()
    }
    catch (Exception e) when (!System.Diagnostics.Debugger.IsAttached)
    {
        Console.WriteLine(exception.Message);
    }
