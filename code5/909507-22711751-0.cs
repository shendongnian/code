    using System;
    
    class Program
    {
        static void Main()
        {
            TestFoo(Foo.A);
            TestEnum(Foo.B);
            TestGenerics(Foo.C);
        }
        static string TestFoo(Foo foo)
        {
            return foo.ToString();
        }
        static string TestEnum(Enum foo)
        {
            return foo.ToString();
        }
        static string TestGenerics<T>(T foo)
        {
            return foo.ToString();
        }
    }
    
    enum Foo
    {
        A, B, C
    }
