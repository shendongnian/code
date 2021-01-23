    public void RegisterRoutes(RouteCollection routes)
    {
        ViewEngines.Engines.Insert(0, new CustomViewEngine());
        var route = routes.MapRoute("Plugin...OrderDetailsOverride",
             "Admin/Order/Edit/{id}",
             new { controller = "MyOrder", action = "Edit" area = "Admin" }, //notice 'area="Admin"' is added
             new { id = @"\d+" },
             new[] { "MyPlugin.Controllers" }
        );
        routes.remove(route); //remove your route from the RouteTable.Routes
        routes.insert(0, route); //only to add it back again to the top of RouteTable.Routes, above all the routes that have been registered earlier
    }
    public int Priority
    {
        get
        {
            return 1;
        }
    }
