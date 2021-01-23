    public void Configuration(IAppBuilder app)
            {
                var container = GetContainer(); // Initialise container
    
                HttpConfiguration config = new HttpConfiguration
                {
                    DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container)           
                };
    
                WebApiConfig.Register(config);       ;
                app.UseWebApi(config);
            }
