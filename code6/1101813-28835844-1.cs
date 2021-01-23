    var scopedLifestyle = new LifetimeScopeLifestyle();
    container.Register<ISomeType, SomeType>(scopedLifestyle);
    using (container.BeginLifetimeScope())
    {
        var some = container.GetInstance<SomeRootObjectDependingOnSomeType>();
        some.Execute();
    }
