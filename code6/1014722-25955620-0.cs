    public static int a0;
    public static int a1;
    public static int a2;
    
    public static Dictionary<string, Action<int>> actions = new Dictionary<string, Action<int>> { 
    {"a0", val => a0 = val}, {"a1", val => a1 = val}, {"a2", val => a2 = val }};
    
    static void Main(string[] args)
    {
        for (int i = 0; i < 3; i++)
            actions["a" + i](i * 2);
    
        Console.WriteLine(a0);
        Console.WriteLine(a1);
        Console.WriteLine(a2);
    }
