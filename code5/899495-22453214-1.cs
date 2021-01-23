        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler((x, y) =>
        {
            var exception = y.ExceptionObject as System.IO.FileNotFoundException;
    
            if (exception != null)
                // Retrieve exception information here
        });
