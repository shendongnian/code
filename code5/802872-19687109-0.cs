    Process consoleProcess = Process.Start(@"C:\Users\Krijn\Desktop\CarWorks\Parts\bin\Debug\Parts");
    // Do some stuff here...
    if (!consoleProcess.HasExited)
    {
        // Terminate the process
        consoleProcess.Kill();
    }
    // Wait until the process is really terminated.
    consoleProcess.WaitForExit();
