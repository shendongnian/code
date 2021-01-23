    public void Run()
    {
      //...
      SetupContainer();
      //...
      RunWebService();
      //...
    }
    public void SetupContainer()
    {
      //This can also be done using a configuration file
      this.container.RegisterType<IAuthorBLL, AuthorBLLImpl>();
      this.container.RegisterType<IBookBLL, BookBLLImpl>();
      this.container.RegisterType<IOther1BLL, Other1BLLImpl>();
      //...
      this.container.RegisterType<IOther50BLL, Other50BLLImpl>();
    }
    public void RunWebService()
    {
      this.container.RegisterType<IWCFService, WCFService>(
          new ContainerControlledLifetimeManager());
      var serviceSingleton = this.container.Resolve<IWCFService>();
      //... proceed with service setup and run
    }
