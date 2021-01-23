    public int Num { get; set; }
    public string Str { get; set; }
    static void Main()
    {
        Test a = new Test() { Num = 1, Str = "Hi" };
        Test b = new Test() { Num = 1, Str = "Hi" };
        bool areEqual = System.Object.ReferenceEquals(a, b);
        // Output will be false
        System.Console.WriteLine("ReferenceEquals(a, b) = {0}", areEqual);
        // Assign b to a.
        b = a;
        // Repeat calls with different results.
        areEqual = System.Object.ReferenceEquals(a, b);
        // Output will be true
        System.Console.WriteLine("ReferenceEquals(a, b) = {0}", areEqual);
      
    }
