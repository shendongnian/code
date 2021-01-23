    private static void Main()
    {
        if (a() && b() && c())
        {
            Console.WriteLine("DoSomething");
        }
    }
    bool a()
    {
        return true;
    }
    bool b()
    {
        return 3 % 2 == 1;
    }
    bool c()
    {
        return (3 % 2) / 1 == 1;
    }
