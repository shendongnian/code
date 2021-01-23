    static void Main(string[] args)
    {
        doCustomCode(() =>
        {
            Console.WriteLine("customCode #1");
        });
        doCustomCode(() =>
        {
            Console.WriteLine("customCode #2");
        });
    }
    private static void doCustomCode(Action action)
    {
        using (var con = new Connection())
        {
            action();
        }
    }
