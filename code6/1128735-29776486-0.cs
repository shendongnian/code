    static void Main(string[] args)
    {
        ContainerBuilder builder = new ContainerBuilder();
        builder.RegisterType<Foo>().AsSelf().InstancePerRequest();
        IContainer container = builder.Build();
        using (ILifetimeScope scope = container.BeginLifetimeScope(
            MatchingScopeLifetimeTags.RequestLifetimeScopeTag))
        {
            scope.Resolve<Foo>();
        }
    }
