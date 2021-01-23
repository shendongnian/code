    string connString = ConfigurationManager.ConnectionStrings["App"].ConnectionString;
    var settings = new AppConfigurationSettings(
        scopedLifestyle: new WcfOperationLifestyle(),
        connectionString: connString,
        sidToRoleMapping: CreateSidToRoleMapping(),
        projectDirectories: ConfigurationManager.AppSettings.GetOrThrow("ProjectDirs"),
        applicationAssemblies:
            BuildManager.GetReferencedAssemblies().OfType<Assembly>().ToArray());
    var container = new Container();
    var connectionFactory = new ConnectionFactory(settings.ConnectionString);
    container.RegisterSingle<IConnectionFactory>(connectionFactory);
    container.RegisterSingle<ITimeProvider, SystemClockTimeProvider>();
    container.Register<IUserContext>(
        () => new WcfUserContext(settings.SidToRoleMapping), settings.ScopedLifestyle);
