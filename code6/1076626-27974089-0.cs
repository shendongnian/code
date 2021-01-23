    //Requres project properties be set to Allow Unsafe Code
    struct Foo
    {
        public int Bar { get; set; }
    }
    static unsafe void Main(string[] args)
    {
        Foo[] list = new Foo[2];
        list[0] = new Foo { Bar = 100 };
        Foo foo = new Foo { Bar = 100 };
        list[1] = foo;
        fixed (Foo* boo = list)
            *boo = new Foo { Bar = 1 };
        foreach (Foo f in list)
            Console.WriteLine(f.Bar); //Prints 1 then 100
        Console.ReadKey();
    }
