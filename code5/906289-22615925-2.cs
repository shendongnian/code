    static void Main()
    {
        Thread t = new Thread(Foo);
        t.Start();
        Console.ReadKey();
    }
    static void Foo()
    {
        Print("Hello from t!");
    }
    static void Print(string message)
    {
        Console.WriteLine(message);
    }
