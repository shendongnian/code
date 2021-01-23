    // makes types FooLicious and FooMinable available as IFoo
    // similar to ninject's Bind<IFoo>().To<FooLicious>().Named("delicious");
    builder.RegisterType<FooLicious>().Named<IFoo>("delicious");
    builder.RegisterType<FooMinable>().Named<IFoo>("abominable");
    //factory delegate definition
    public delegate IFoo FooFactory(string name);
    builder.Register<FooFactory>(c => 
    {
        var context = c.Resolve<IComponentContext>();
        return name => 
        {
            return context.ResolveNamed<IFoo>(name);
        };
    });
    FooFactory factory = container.Resolve<FooFactory>();
    IFoo = factory("delicious"); // returns a FooDelicious
