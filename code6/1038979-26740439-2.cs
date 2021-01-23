    // b.exe
    static void Main(string[] args)
    {
        // using command line arguments
        foreach (var arg in args)
            ProcessArg(arg);
        // if using input, then use something like if processing line by line
        // string line = Console.ReadLine();
        // while (line != "exit" || !string.IsNullOrEmpty(line))
        //     ProcessArg(line);
        // or you can read the input stream
        var reader = new StreamReader(Console.OpenStandardInput());
        var text = reader.ReadToEnd();
        // TODO: parse the text and find the commands
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
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
        };
        var p = new Process() { StartInfo = psi };
        p.ErrorDataReceived += p_ErrorDataReceived;
        p.OutputDataReceived += p_OutputDataReceived;
        p.Start();
        p.BeginErrorReadLine();
        p.BeginOutputReadLine();
        // if sending data through standard input (May need to use Write instead
        // of WriteLine. May also need to send end of stream (0x04 or ^D / Ctrl-D)
        StreamWriter writer = p.StandardInput;
        writer.WriteLine("help");
        writer.WriteLine("call");
        writer.WriteLine("exit");
        writer.Close();
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
