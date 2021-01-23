    static void Main()
    {
        Task<string> pingReply = RunCommand("ping", "bing.com");
        
        Console.WriteLine("I am waiting for ping to complete and could be doing something useful");
        pingReply.Wait();
                
        Console.WriteLine(pingReply.Result);
        Console.ReadKey();
    }
    public static Task<string> RunCommand(string command, string args)
    {
        ProcessStartInfo cmdStartInfo = new ProcessStartInfo()
        {
            FileName = command,
            Arguments = args,
            RedirectStandardOutput = true,
            CreateNoWindow = true,
            UseShellExecute = false
        };
        Process proc = Process.Start(cmdStartInfo);        
        Task<string> readCommand = proc.StandardOutput.ReadToEndAsync();
        return readCommand;
    }
