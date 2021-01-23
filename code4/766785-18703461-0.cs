    static void Main(string[] args)
    {
        int x = 1;
        Increment(x);
        Console.WriteLine("{0}");
    }
    static void Increment(int x)
    {
        x = ++x;
    }
