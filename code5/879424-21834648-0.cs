    private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() => {
        var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unityConfiguration");
        return new UnityContainer().LoadConfiguration(section);
    });
    public static IUnityContainer GetConfiguredContainer() {
        return container.Value;
    }
