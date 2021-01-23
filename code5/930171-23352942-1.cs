    private Container ContainerFactory()
    {
        var container = new Container();
        container.Register<ISettings, GoodSettings>();
        container.RegisterAll<IOneOfMany>(this.GetAllOfThem(container));
        container.Register<IOneOfMany>(() => this.GetTheOneIWant(container));
        return container;
    }
    private IEnumerable<Type> GetAllOfThem(Container container)
    {
        var types = OpenGenericBatchRegistrationExtensions
            .GetTypesToRegister(
                container,
                typeof(IOneOfMany),
                AccessibilityOption.AllTypes,
                typeof(IOneOfMany).Assembly);
        return types;
    }
