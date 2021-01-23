    protected void Application_Start() {
      // initialization of unity container
      ServiceLocator.IoC = ...; 
      var factory = new MgsMvcControllerFactory()
      ControllerBuilder.Current.SetControllerFactory(factory);
    }
