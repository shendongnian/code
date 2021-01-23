    static void StaticMethod(int x)
    {
        // This uses ldarg.0
        Console.WriteLine(x);
    }
    void InstanceMethod(int x)
    {
        // This uses ldarg.1
        Console.WriteLine(x);
    }
