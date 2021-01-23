    [Test]
    public void Get1()
    {
        var container = new WindsorContainer();
        container.Register(Component.For<SomeClass>().LifestyleSingleton());
        container.Register(Component.For<Dependency>().LifestyleSingleton());
            
        var graphNodes = container.Kernel.GraphNodes;
            
        Assert.That(graphNodes.Length, Is.EqualTo(2));
        Assert.That(graphNodes[0].Dependents[0].ToString(), Is.EqualTo(typeof(Dependency).Name));
        Assert.That(graphNodes[1].Dependents.Length, Is.EqualTo(0));
    }
