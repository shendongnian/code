    public delegate void myDelegate();
    
    private static void Main()
    {
        myDelegate myFunctions = Method1;
        myFunctions += Method2;
    
        myFunctions();
    }
    
    public static void Method1()
    {
        Console.WriteLine("Hello from method1");
    }
    
    public static void Method2( )
    {
        Console.WriteLine("Hello from method2");
    }
