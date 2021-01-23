    var process = Process.GetCurrentProcess();
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(process.PrivateMemorySize64 + Environment.NewLine);
        process.Refresh();
    }
