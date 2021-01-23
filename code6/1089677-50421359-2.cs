    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ....
        app.UseMvc(routes =>
        {
            routes.MapRouteAnalyzer("/routes"); // Add
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action=Index}/{id?}");
        });
    }
