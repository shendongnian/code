    builder.RegisterType<DataContext>().InstancePerHttpRequest();
    
    builder.RegisterType<AnnoucementRepository>()
           .As<IAnnouncementRepository>().InstancePerHttpRequest();
    builder.RegisterType<LanguageRepository>()
           .As<ILanguageRepository>().InstancePerHttpRequest();
