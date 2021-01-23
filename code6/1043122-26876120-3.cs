    [TestMethod]
    public void UnityHasMeScratchingMyHead()
    {
        var container = new UnityContainer();
        container.RegisterType<Func<Inner>>(new PerResolveLifetimeManager(), new InjectionFactory(x =>
        {
            var child = x.CreateChildContainer();
            child.RegisterType<Inner>(new ContainerControlledLifetimeManager());
            return new Func<Inner>(() => child.Resolve<Inner>());
        }));
        var outer1 = container.Resolve<Outer>();
        var inner1 = outer1.InnerFactory();
        var inner2 = outer1.InnerFactory();
        var outer2 = container.Resolve<Outer>();
        var inner3 = outer2.InnerFactory();
        var inner4 = outer2.InnerFactory();
        Assert.AreNotSame(outer1, outer2, "outer1 == outer2");
        Assert.AreSame(inner1, inner2, "inner1 != inner2");
        Assert.AreNotSame(inner2, inner3, "inner2 == inner3");
        Assert.AreSame(inner3, inner4, "inner3 != inner4");
    }
