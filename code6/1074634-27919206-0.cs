    var types = OpenGenericBatchRegistrationExtensions
        .GetTypesToRegister(
            container,
            typeof (INotificationHandler<>),
            AccessibilityOption.AllTypes,
            AppDomain.CurrentDomain.GetAssemblies())
        .ToList();
    
    container.RegisterAll(typeof (INotificationHandler<>), types);
