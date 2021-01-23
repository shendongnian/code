    IoC.Register<MySqlThingRepository>().As<IThingRepository>();
    IoC.Register<MicrosoftExchangeEmailer>().As<IEmailer>();
    IoC.Register<TruncatingFileLogger>().As<ILogger>();
    IoC.Register<MoreStuff>().As<INeedMoreStuff>();
    IoC.Register<Thing>().As<IThing>();
