    IUnityContainer container = new UnityContainer();
            
    container.AddNewExtension<EnterpriseLibraryCoreExtension>();
    var instrumentationSection = 
        ConfigurationManager.GetSection(InstrumentationConfigurationSection.SectionName) 
        as InstrumentationConfigurationSection;
    if (instrumentationSection != null)
    {
        var provider = new MyLoggingInstrumentationProvider(
            instrumentationSection.PerformanceCountersEnabled,
            instrumentationSection.EventLoggingEnabled,
            instrumentationSection.ApplicationInstanceName);
        container.RegisterInstance<ILoggingInstrumentationProvider>(provider);
    }
    else
    {
        // Throw since we want this to fail if not configured
        throw new Exception(InstrumentationConfigurationSection.SectionName 
            + " configuration section was not found.");
    }
    EnterpriseLibraryContainer.Current = new UnityServiceLocator(container);
