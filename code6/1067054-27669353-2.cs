    [Fact]
    public void RegistersIHandleQuery_UsingOpenGenerics_WithDecorationChain()
    {
        var container = this.ContainerFactory();
        var instance = container
            .GetInstance<IHandleQuery<FakeQueryWithoutValidator, string>>();
        var registration = (
            from currentRegistration in container.GetCurrentRegistrations()
            where currentRegistration.ServiceType ==
                typeof(IHandleQuery<FakeQueryWithoutValidator, string>)
            select currentRegistration.Registration)
            .Single();
        Assert.Equal(
            typeof(QueryNotNullDecorator<FakeQueryWithoutValidator, string>), 
            registration.ImplementationType);
        Assert.Equal(Lifestyle.Singleton, registration.Lifestyle);
        registration = registration.GetRelationships().Single().Dependency.Registration;
        Assert.Equal(
            typeof(QueryLifetimeScopeDecorator<FakeQueryWithoutValidator, string>), 
            registration.ImplementationType);
        Assert.Equal(Lifestyle.Singleton, registration.Lifestyle);
        registration = registration.GetRelationships().Single().Dependency.Registration;
        Assert.Equal(
            typeof(ValidateQueryDecorator<FakeQueryWithoutValidator, string>), 
            registration.ImplementationType);
        Assert.Equal(Lifestyle.Transient, registration.Lifestyle);
    }
