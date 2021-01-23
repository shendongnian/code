    try
    {
        await DoSomething(new Progress<string>(status => Console.WriteLine(status)));
        Console.WriteLine("COMPLETED");
    }
    catch (Exception e)
    {
        Console.WriteLine("EXCEPTION: " + e.Message);
    }
