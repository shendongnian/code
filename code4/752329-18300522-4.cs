    if (Debugger.IsAttached)
    {
        AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
        {
            Console.Write("\nPress Any Key to Continue");
            Console.ReadKey();
        };
    }
