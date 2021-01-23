    TimeSpan timeOut = TimeSpan.FromSeconds(Int32.Parse(
        ConfigurationManager.AppSettings["timeOut"]));
    container.RegisterType<IRepository<Employee>, Repository<Employee>>();
    container.RegisterType<IEmployeeService, EmployeeService>());
    container.Register<IEmployeeService>(new InjectionFactory(c =>
        new EmployeeService(
            c.Resolve<IRepository<Employee>>(),
            timeOut)));
