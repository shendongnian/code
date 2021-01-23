    [Test]
    public void Resolve1()
    {
        var container = new WindsorContainer();
        container.Register(Component.For<SomeClass>().LifestyleSingleton());
        container.Register(Component.For<Dependency>().LifestyleSingleton());
        var graphNodes = container.Kernel.GraphNodes;
        var name = (graphNodes[0] as ComponentModel).ComponentName.ToString();
        var type = Type.GetType(name);
        dynamic instance1 = container.Resolve(type);
        Assert.That(instance1, Is.Not.Null);
    }
