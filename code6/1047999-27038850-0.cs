     CompositionRoot = new CompositionRoot(); 
                HttpConfiguration config = GlobalConfiguration.Configuration;
                
                ControllerBuilder.Current.SetControllerFactory(CompositionRoot);
                config.Services.Replace(typeof(IHttpControllerActivator), CompositionRoot);
                var apiAuthenticationProvider = new ApiAuthenticationProvider(new HashGenerator());
                config.Services.Add(typeof(System.Web.Http.Filters.IFilterProvider), new BasicAuthenticationFilterProvider(apiAuthenticationProvider));
