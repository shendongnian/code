    if (!Startup.AttachConsole(-1))
    { 
        // Attach to an parent process console
        Startup.AllocConsole(); // Alloc a new console
    }
    
    Console.WriteLine("hey");
    Startup.FreeConsole();
