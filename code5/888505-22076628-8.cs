    IBindingRoot.Bind(x => x
        .FromThisAssembly()
        .IncludingNonePublicTypes()
        .SelectAllClasses()
        .InheritedFrom(typeof(IRepository<>))
        .Exclude<MessageRepository>()
        .BindDefaultInterface()
        .Configure(y => y.InRequestScope()));
    IBindingRoot.Bind<IMessageRepository>().To<MessageRepository>)
        .WithConstructorArgument("apikey", AppSettingsManager.GetSmsApiKey)
        .InRequestScope();
