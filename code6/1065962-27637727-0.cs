    class A
    {
        public int a;
    }
    static void Main(string[] args)
    {
        A a1 = new A();
        A b1 = new A();
        int a = 123;
        a1.a = 123;
        int b = 31;
        b1.a = 31;
        a = b;
        a1 = b1;
        b = 312;
        b1.a = 312;
        Console.WriteLine(a);
        Console.WriteLine(a1.a);
        Console.ReadLine();
    }
