    [Test]
    public void Build_Returns_Container_With_Resolvable_Repo()
    {
        using (container = ContainerBuilder.Build())
        {
           var actualContainerRepo = container.Resolve<IContainerRepository>();
           Assert.IsNotNull(actualContainerRepo);
        }
    }
