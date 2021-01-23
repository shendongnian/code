    private void RegisterSubscribers(Container container)
    {
        Type[] openGenericSubscribers = new[]
        { 
            typeof(SubscribeToIMarker1<>),
            typeof(SubscribeToIMarker2<>),
            typeof(SubscribeToIMarker3<>)
        };
        var nonGenericSubscribers = OpenGenericBatchRegistrationExtensions
            .GetTypesToRegister(container,
                typeof(ISubscribeTo<>),
                AccessibilityOption.PublicTypesOnly,
                AppDomain.CurrentDomain.GetAssemblies());
        container.RegisterManyForOpenGeneric(typeof(ISubscribeTo<>),
            container.RegisterAll,
            nonGenericSubscribers.Concat(openGenericSubscribers));
        container.RegisterAllOpenGeneric(typeof(ISubscribeTo<>), 
            openGenericSubscribers);
        container.Verify();
    }
