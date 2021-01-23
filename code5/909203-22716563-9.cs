    [Test]
    public void CompositeHandlerForType3_Resolves_WithAlphaAndBetaHandlers()
    {
        var container = this.ContainerFactory();
        var result = container.GetInstance<ContainerResolvedClass<Type3>>();
        var handlers = result.Handlers.Select(x => x.GetType());
        Assert.That(handlers.Count(), Is.EqualTo(2));
        Assert.That(handlers.Contains(typeof(AlphaHandler<Type3>)), Is.True);
        Assert.That(handlers.Contains(typeof(BetaHandler<Type3>)), Is.True);
    }
