    class Program
    {
        static void Main(string[] args)
        {
            var foo1 = new Foo<MyNullable<int>>();
            Console.WriteLine(foo1.IsNull()); // true
            var foo2 = new Foo<MyNullable<int>>();
            foo2.Item = 3;
            Console.WriteLine(foo2.IsNull()); // false
            var foo3 = new Foo<object>();
            Console.WriteLine(foo3.IsNull()); // true
            var foo4 = new Foo<object>();
            foo4.Item = new object();
            Console.WriteLine(foo4.IsNull()); // false
            var foo5 = new Foo<MyNullable<int>>();
            int integer = foo5.Item;
            Console.WriteLine(integer); // 0
            var foo6 = new Foo<MyNullable<double>>();
            double real = foo6.Item;
            Console.WriteLine(real); // 0
            var foo7 = new Foo<MyNullable<double>>();
            foo7.Item = null;
            Console.WriteLine(foo7.Item); // 0
            Console.WriteLine(foo7.IsNull()); // true
            foo7.Item = 3.5;
            Console.WriteLine(foo7.Item); // 3.5
            Console.WriteLine(foo7.IsNull()); // false
            // var foo5 = new Foo<int>(); // Not compile
        }
    }
