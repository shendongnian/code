    container.RegisterPerWebRequest<ConnectionSelector>();
    container.RegisterPerWebRequest<DbContext>(() => new DbContext(
        container.GetInstance<ConnectionSelector>().AsReadOnly 
            ? "ReadOnlyConnection" 
            : "NormalConnection"));
    container.RegisterSingle<IControllerFactory>(
        new ReadOnlySwitchControllerFactory(container));
