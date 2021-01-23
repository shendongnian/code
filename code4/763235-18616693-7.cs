    IUnityContainer container = new UnityContainer();
    container.AddNewExtension<EnterpriseLibraryCoreExtension>();
    var instrumentationSection =
        ConfigurationManager.GetSection(InstrumentationConfigurationSection.SectionName)
        as InstrumentationConfigurationSection;
    ILoggingInstrumentationProvider provider = null;
    if (instrumentationSection != null)
    {
        provider = new MyLoggingInstrumentationProvider(
            instrumentationSection.PerformanceCountersEnabled,
            instrumentationSection.EventLoggingEnabled,
            instrumentationSection.ApplicationInstanceName);
    }
    else
    {
        provider = new MyLoggingInstrumentationProvider(false, false, "DefaultApplication");
    }
    container.RegisterInstance<ILoggingInstrumentationProvider>(provider);
    EnterpriseLibraryContainer.Current = new UnityServiceLocator(container);
