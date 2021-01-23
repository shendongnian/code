        public void ConfigureAuth(IAppBuilder app)
        {
			app.CreatePerOwinContext(CreateKernel);
			app.UseNinjectMiddleware(CreateKernel);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
         }
