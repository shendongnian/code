    static void Main(string[] args)
    {
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
            File.WriteAllText(@"C:\Polygon\Test.txt", "test");
        }
    }
