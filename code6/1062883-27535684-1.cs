    class Program
    {
        class A
        {
            public Guid Guid { get; private set; }
            public A()
            {
                Guid = Guid.NewGuid();
            }
        }
        static void Main(string[] args)
        {
            // Set up data values
            A a = new A();
            Guid guid = a.Guid;
            // Create expressions to be composed
            Expression<Func<A, Guid>> e1 = arg => arg.Guid, e2 = arg => guid;
            // Create lambda expression: invoke both expressions, compare the result
            ParameterExpression param1 = Expression.Parameter(typeof(A));
            Expression<Func<A, bool>> e3 = Expression.Lambda<Func<A, bool>>(
                Expression.Equal(
                    Expression.Invoke(e1, param1),
                    Expression.Invoke(e2, param1)),
                param1);
            // Compile to an actual delegate instance
            Func<A, bool> d1 = e3.Compile();
            // Check the result
            Console.WriteLine(d1(a));
        }
    }
