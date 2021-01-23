    [Test]
    public void CompositeHandlerForType1_Resolves_WithAlphaHandler()
    {
        var container = this.ContainerFactory();
        var result = container.GetInstance<ContainerResolvedClass<Type1>>();
        var handlers = result.Handlers.Select(x => x.GetType());
        Assert.That(handlers.Count(), Is.EqualTo(1));
        Assert.That(handlers.Contains(typeof(AlphaHandler<Type1>)), Is.True);
    }
