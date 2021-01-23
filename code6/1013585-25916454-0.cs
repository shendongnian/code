    static void Main(string[] args)
    {
        var procs = Process.GetProcessesByName("LINQPad").ToList();
        if (procs.Any())
        {
            procs.ForEach(p => p.EnableRaisingEvents = true);
            procs.ForEach(p => p.Exited += OnExited);
            procs.ForEach(p => p.WaitForExit());
        }
        Console.WriteLine("All processes exited...");
        Console.ReadKey();
    }
    private static void OnExited(object sender, EventArgs eventArgs)
    {
        Console.WriteLine("Process Has Exited");
    }
