    IContainer container = new Container();
    container.Configure(c =>
    {
        c.IncludeRegistry<ConfigurationRegistry>();
    });
    IContainer myNestedContainer = container.GetNestedContainer();
    myNestedContainer.Dispose();
