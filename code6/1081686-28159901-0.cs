    private static void RegisterDependencies(IUnityContainer container)
    {
        // TODO: Add any dependencies needed here
        container
            .RegisterType(typeof(TabItemSpacerControlLite), typeof(TabItemSpacerControlLite), new InjectionConstructor(typeof(TabBase)));
    }
