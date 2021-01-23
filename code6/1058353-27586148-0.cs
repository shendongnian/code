    public void Configure(IApplicationBuilder app)
    {
        // Use OWIN bridge to map between ASP.NET 5 and Katana / OWIN
        app.UseAppBuilder(appBuilder =>
        {
            // Some components will have dependencies that you need to populate in the IAppBuilder.Properties.
            // Here's one example that maps the data protection infrastructure.
            appBuilder.SetDataProtectionProvider(app);
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration(); 
            config.Routes.MapHttpRoute( 
                name: "DefaultApi", 
                routeTemplate: "api/{controller}/{id}", 
                defaults: new { id = RouteParameter.Optional } 
            );
            appBuilder.UseWebApi(config);
        };
    }
