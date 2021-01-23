    var builder = new ContainerBuilder();
    builder.RegisterType<Main>().As<IMain>().InstancePerDependency();
    builder.RegisterType<Dep>().As<IDep>().InstancePerDependency();
    builder.RegisterType<Sub>().As<ISub>().InstancePerLifetimeScope();
    var container = builder.Build();
    using (var lifetimeScope = container.BeginLifetimeScope())
    {
        var main = lifetimeScope.Resolve<IMain>();
    }
