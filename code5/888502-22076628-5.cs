    IBindingRoot.Bind(x => x
        .FromThisAssembly()
        .IncludingNonePublicTypes()
        .SelectAllClasses()
        .InheritedFrom(typeof(IRepository<>))
        .Exclude<MessageRepository>()
        .BindDefaultInterface()
        .Configure(x => x.InRequestScope()));
    IBindingRoot.Bind<IMessageRepository>().To<MessageRepository>)
        .WithConstructorArgument("apikey", AppSettingsManager.GetSmsApiKey)
        .InRequestScope();
