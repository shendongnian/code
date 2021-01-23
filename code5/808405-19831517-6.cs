    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Foo<MyNullable<int>>().IsNull()); // true
            Console.WriteLine(new Foo<MyNullable<int>> {Item = 3}.IsNull()); // false
            Console.WriteLine(new Foo<object>().IsNull()); // true
            Console.WriteLine(new Foo<object> {Item = new object()}.IsNull()); // false
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
