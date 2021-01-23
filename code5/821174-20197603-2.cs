    using (container = ContainerBuilder.Build())
    {
       var actualContainerRepo = container.Resolve<IContainerRepository>();
       Assert.IsNotNull(actualContainerRepo);
    }
}`
