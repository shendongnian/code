    public void Start()
    {
        lock (_lockObject)
        {
            if (_started) return;
            _started = true;
    
            HostingEnvironment.RegisterObject(this);
            
            //This will create the DB if it doesn't exist
            var db = new HangfireContext();
    
            GlobalConfiguration.Configuration.UseSqlServerStorage("HangfireContext");
            
    	   // See the next section on why we set the ServerName
            var options = new BackgroundJobServerOptions()
            {
                ServerName = ConfigurationManager.AppSettings["HangfireServerName"]
            };
    
            _backgroundJobServer = new BackgroundJobServer(options);
    
            var jobStarter = DependencyResolver.Current.GetService<JobBootstrapper>();
    		
            //See the Recurring Jobs + SimpleInjector section
            jobStarter.Bootstrap();
                   
        }
    }
