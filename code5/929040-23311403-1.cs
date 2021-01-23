    public delegate void myDelegate();
    
    private static void Main()
    {
        myDelegate myFunctions = Method1; //initialize delegate with Method1
        myFunctions += Method2;           //Add Method2 to delegate
    
        myFunctions(); //call all methods added to delegate
    }
    
    public static void Method1()
    {
        Console.WriteLine("Hello from method1");
    }
    
    public static void Method2( )
    {
        Console.WriteLine("Hello from method2");
    }
