    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler((x, y) =>
    {
        var exception = y.ExceptionObject as Exception;
        if (exception is System.IO.FileNotFoundException)
            Console.WriteLine("Please make sure the DLL is in the same folder.");
    });
