        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(GetAssemblies(true)).PropertiesAutowired();
            builder
                .RegisterAssemblyTypes(GetAssemblies(false))             
                .Where(t => t.GetCustomAttributes(typeof(IocContainerMarkerAttribute), false).Any())
                .AsImplementedInterfaces()
                .PropertiesAutowired();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }
        private static Assembly[] GetAssemblies(bool isController)
        {
            var path = HttpContext.Current.Server.MapPath("~/Bin");
            return isController
                ? Directory.GetFiles(path, "*.dll").Where(x => x.Contains(".Controllers")).Select(Assembly.LoadFrom).ToArray()
                : Directory.GetFiles(path, "*.dll").Where(x => !x.Contains(".Controllers")).Select(Assembly.LoadFrom).ToArray();
        }
