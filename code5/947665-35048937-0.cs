    public void Configuration(IAppBuilder app)
    {
      var kernel = CreateKernel()
      var config = new HttpConfiguration();
      config.MapHttpAttributeRoutes();
    
      // USE kernel here
    
      app.UseNinjectMiddleware(() => kernel);
      app.UseNinjectWebApi(config);
    }
