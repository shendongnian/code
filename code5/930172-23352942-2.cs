    private IOneOfMany GetTheOneIWant(Container container)
    {
        var settings = container.GetInstance<ISettings>();
        var result = container
            .GetAllInstances<IOneOfMany>()
            .SingleOrDefault(i => i.GetType().Name == settings.IWantThisOnePlease);
        return result;
    }
