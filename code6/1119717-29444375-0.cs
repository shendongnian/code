    class Program
    {
        private static IServiceContainer container = new ServiceContainer();
        
        static void Main(string[] args)
        {
            container.Register(f => new Foo("PerScopeFoo"), "PerScopeFoo", new PerScopeLifetime());
            container.Register(f => new Foo("PerRequestFoo"), "PerRequestFoo", new PerRequestLifeTime());
            container.Register(f => new Foo("PerContainerFoo"), "PerContainerFoo", new PerScopeLifetime());
            container.Register(f => new Foo("TransientFoo"), "TransientFoo");
            using (container.BeginScope())
            {
                var first = container.GetInstance<Foo>("PerScopeFoo");
                var second = container.GetInstance<Foo>("PerScopeFoo");
                Debug.Assert(first == second);
                first = container.GetInstance<Foo>("PerRequestFoo");
                second = container.GetInstance<Foo>("PerRequestFoo");
                Debug.Assert(first != second);
                first = container.GetInstance<Foo>("PerContainerFoo");
                second = container.GetInstance<Foo>("PerContainerFoo");
                Debug.Assert(first == second);
                first = container.GetInstance<Foo>("TransientFoo");
                second = container.GetInstance<Foo>("TransientFoo");
                Debug.Assert(first != second);
            }
            container.Dispose();
            Console.ReadKey();
        }        
    }
    public class Foo : IDisposable
    {
        private readonly string name;
        public Foo(string name)
        {
            this.name = name;
        }
        public void Dispose()
        {
            Console.WriteLine(name + " disposed");
        }
    }
