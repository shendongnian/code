    static void Main(string[] args)
    {
        A foo = new A();
        foo.data = 20;
        B bar = new B(new A{ data = foo.data; });
        Console.WriteLine(bar.a.data); // prints 20
        Console.WriteLine(foo.data); //prints 20
        foo.data = 10;
        bar.a.data = 30;
        Console.WriteLine(bar.a.data); // prints 30
        Console.WriteLine(foo.data); //prints 10
    }
