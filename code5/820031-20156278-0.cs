    using (var lifetimeScope = container.BeginLifetimeScope())
    {
        foobar1 = lifetimeScope.Resolve<FooBar>();
    }
    using (var lifetimeScope = container.BeginLifetimeScope())
    {
        foobar2 = lifetimeScope.Resolve<FooBar>();
    }
