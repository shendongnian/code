    public static void Test() {
        Derived.Value=10;
        Console.WriteLine(Base.Value);
        Base.Value=20;
        Console.WriteLine(Derived.Value);
        Base.Nested bn=new Derived.Nested();
        Derived.Nested dn=new Base.Nested();
        Console.WriteLine(typeof(Base.Nested).FullName);
        Console.WriteLine(typeof(Derived.Nested).FullName);
        Console.WriteLine(typeof(Base.Nested)==typeof(Derived.Nested));
    }
