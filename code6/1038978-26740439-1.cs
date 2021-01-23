    // b.exe
    static void Main(string[] args)
    {
        // using command line arguments
        foreach (var arg in args)
            ProcessArg(arg);
        // if using input, then use something like
        // string line = Console.ReadLine();
        // while (line != "exit" || !string.IsNullOrEmpty(line))
        //     ProcessArg(line);
    }
    static void ProcessArg(string arg)
    {
        if (arg == "help") Console.WriteLine("b.exe help output");
        if (arg == "call") Console.WriteLine("b.exe call output");
        if (arg == "command") Console.WriteLine("b.exe command output");
    }
    // a.exe
    static void Main(string[] args)
    {
        // Testing -- Send help, call, command  --> to b.exe
        var psi = new ProcessStartInfo("b.exe", "help call command")
        {
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
        };
        var p = new Process() { StartInfo = psi };
        p.ErrorDataReceived += p_ErrorDataReceived;
        p.OutputDataReceived += p_OutputDataReceived;
        p.Start();
        p.BeginErrorReadLine();
        p.BeginOutputReadLine();
        p.WaitForExit();
    }
    static void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
    {
        Console.Error.WriteLine("a.exe error: " + e.Data ?? "(null)");
    }
    static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine("a.exe received: " + e.Data ?? "(null)");
    }
