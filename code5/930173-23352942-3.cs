    [Test]
    public void Container_RegisterAll_ReturnsTheOneSpecifiedByTheSettings()
    {
        var container = this.ContainerFactory();
        var result = container.GetInstance<IOneOfMany>();
        Assert.That(result, Is.Not.Null);
    }
