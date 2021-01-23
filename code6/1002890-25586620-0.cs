    using System;
    class Test
    {
        public static T Foo<T>(object x)
        {
           return default(T);
        }
        public static void Main(string[] args)
        {
            object a = new object();
            dynamic b = a;
            var c = Foo<string>(a);
            var d = Foo<string>(b);
            Console.WriteLine(c.SomeRandomMember); // Invalid
            Console.WriteLine(d.SomeRandomMember); // Valid
        }
    }
