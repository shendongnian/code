    static void Main(string[] args)
    {
        A foo = new A();
        foo.data = 20;
        B bar = new B(new A());
        Console.WriteLine(bar.a.data); // prints 9
        Console.WriteLine(foo.data); //prints 20
    }
