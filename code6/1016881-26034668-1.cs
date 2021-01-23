    class A
    {
        public A(int id, B b, C c)
        {
            Trace.WriteLine("Got " + id);
        }
    }
    
    class B { }
    
    class C { }
    
    static void Main(string[] args)
    {
        using (var unity = new UnityContainer())
        {
            unity.RegisterType<A>(
                "compile-time", 
                new InjectionConstructor(-1, 
                    new ResolvedParameter<B>(), 
                    new ResolvedParameter<C>()
                    )
            );
            unity.RegisterType<A>(
                new InjectionFactory(
                u => u.Resolve<A>("compile-time", 
                    new ParameterOverride("id", new Random().Next()))
                )
            );
            unity.Resolve<A>();
            unity.Resolve<A>();
            unity.Resolve<A>();
        }
    }
