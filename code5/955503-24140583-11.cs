    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.ProcessExit += CleanUp;
        Task.Factory.StartNew(Method);
        Task.Delay(1000);
    }
    static void Method()
    {
        try
        {
            while (true) { }
        }
        finally
        {
            CleanUp(null, EventArgs.Empty);
        }
    }
    static void CleanUp(object sender, EventArgs args)
    {
        File.WriteAllText(@"C:\Polygon\Test.txt", "test");
    }
