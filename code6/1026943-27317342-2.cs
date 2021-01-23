    var builder= new ContainerBuilder();
    builder.RegisterControllers(Assembly.GetExecutingAssembly()); //Register MVC Controllers
    builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers
    //Register any other components required by your code....
    
    var container = builder.Build();
    DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //Set the MVC DependencyResolver
    GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
