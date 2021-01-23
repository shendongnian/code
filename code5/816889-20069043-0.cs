    [DllImport("kernel32.dll")]
    private static extern void ExitThread(uint dwExitCode);
    static void Main(string[] args)
    {
        new Thread(Target).Start();
        Console.ReadLine();
    }
    private static void Target()
    {
        using (var file = File.Open("test.txt", FileMode.OpenOrCreate))
        {
            ExitThread(0);
            GC.KeepAlive(file);
        }
    }
