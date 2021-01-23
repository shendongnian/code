    protected void Application_Start()
            {
                //AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(WebApiConfig.Register);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    
                InitializeDocumentStore();
    
            }
    
            public static IDocumentStore Store { get; private set; }
            
            private static void InitializeDocumentStore()
            {
                NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8282);
                Store = new EmbeddableDocumentStore
                {
                    ConnectionStringName = "RavenDB",
                    UseEmbeddedHttpServer = Convert.ToBoolean(ConfigurationManager.AppSettings["ravenhost"]),
                    Conventions = { IdentityPartsSeparator = "-" },
                    Configuration = { Port = 8282 }
                };
                Store.Initialize();
                
            }
