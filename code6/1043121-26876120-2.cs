    [TestMethod]
    public void UnityHasMeScratchingMyHead()
    {
        var container = new UnityContainer();
        container.RegisterType<Inner>(new PerResolveLifetimeManager());
        var outer1 = container.Resolve<Outer>();
        //... and so on.
