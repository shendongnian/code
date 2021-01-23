    [Fact]
    public void RegisterAll_WithOpenAndClosedGenerics_Succeeds()
    {
        var container = new Container();
        var types = OpenGenericBatchRegistrationExtensions
            .GetTypesToRegister(
                container,
                typeof(INotificationHandler<>),
                AccessibilityOption.AllTypes,
                AppDomain.CurrentDomain.GetAssemblies())
            .ToList();
        types.Add(typeof(GenericHandler<>));
        container.RegisterAll(typeof(INotificationHandler<>), types);
        var result = container.GetAllInstances<INotificationHandler<Pinged>>().ToList();
        Assert.Equal(3, result.Count());
    }
