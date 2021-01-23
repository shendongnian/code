    static void Main(string[] args)
    {
        try
        {
            var myService = new MyService();
            myService.OnStart(args);
            Thread.Sleep(Timeout.Infinite);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
