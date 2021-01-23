    var appDomain = AppDomain.CreateDomain("Loader");
    try
    {
        //Here I assume that Loader class is in the same assembly as this code
        var loader = (Loader)appDomain.CreateInstanceAndUnwrap(
            Assembly.GetExecutingAssembly().FullName, 
            typeof (Loader).FullName);
        loader.LoadAndRunBadAssembly();
        Console.WriteLine("Waiting...");
        Thread.Sleep(20000); //This simulates waiting for external code
        if (loader.IsCompleted)
            Console.WriteLine("Processing has finished");
        else if (loader.IsFaulted)
            Console.WriteLine("There was an error");
        else
            Console.WriteLine("It lasts too long");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
    finally
    {
        AppDomain.Unload(appDomain);
    }
