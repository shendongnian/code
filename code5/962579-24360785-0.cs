    interface ICanFoo
    {
        string Foo();
    }
    class TypeX : ICanFoo
    {
        public string Foo()
        {
            return "I'm a TypeX!";
        }
    }
    class TypeY : ICanFoo
    {
        public string Foo()
        {
            return "I'm a TypeY!";
        }
    }
    void foo(ICanFoo x)
    {
        Console.WriteLine(x.Foo());
    }
