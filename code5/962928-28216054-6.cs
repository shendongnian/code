        public void ConfigureAuth(IAppBuilder app)
        {
            // Dependency Injection
            Evoq.AppName.Configuration.Ninject.NinjectHttpContainer.RegisterAssembly();
            // Configure the db context and user manager to use a single instance per request
            
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
    ...
