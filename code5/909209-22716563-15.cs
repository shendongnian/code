    [Test]
    public void CompositeHandlerForType2_Resolves_WithAlphaHandler()
    {
        var container = this.ContainerFactory();
        var result = container.GetInstance<ContainerResolvedClass<Type2>>();
        var handlers = result.Handlers.Select(x => x.GetType());
        Assert.That(handlers.Count(), Is.EqualTo(1));
        Assert.That(handlers.Contains(typeof(BetaHandler<Type2>)), Is.True);
    }
	
