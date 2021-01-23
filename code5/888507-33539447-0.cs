    IBindingRoot.Bind(x => x
    .FromThisAssembly()
    .SelectAllClasses()
    .BindAllInterface());
    IBindingRoot.Rebind<IMessageRepository>().To<MessageRepository>)
    .WithConstructorArgument("apikey", AppSettingsManager.GetSmsApiKey)
    .InRequestScope();
