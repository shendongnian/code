    [STAThread]
    static void Main()
    {
        Task<string> prepWork = Task.Run(() => DoWork());
        Application.Run(new SetOperation(prepWork));
    }
    private static string DoWork()
    {
        Thread.Sleep(1000);//placeholder for real work
        return "hi";
    }
