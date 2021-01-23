    var scopedLifestyle = new AsyncScopedLifestyle();
    container.Register<ISomeType, SomeType>(scopedLifestyle);
    using (AsyncScopedLifestyle.BeginScope(container))
    {
        var some = container.GetInstance<SomeRootObjectDependingOnSomeType>();
        some.Execute();
    }
