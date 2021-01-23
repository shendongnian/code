    static ConsoleEventDelegate handler;
    private delegate bool ConsoleEventDelegate(int eventType);
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
    private static MyExternalProcess p1;
    public static void Main()
    {
        Console.CancelKeyPress += delegate
        {
            killEveryoneOnExit();
        };
        handler = new ConsoleEventDelegate(ConsoleEventCallback);
        SetConsoleCtrlHandler(handler, true);
        p1 = new MyExternalProcess();
        p1.startProcess();
    }
    public static void killEveryoneOnExit()
    {
        p1.kill();
    }
    static bool ConsoleEventCallback(int eventType)
    {
        if (eventType == 2)
        {
            killEveryoneOnExit();
        }
        return false;
    }
