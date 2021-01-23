    protected void Application_Start(object sender, EventArgs e)
    {
        // Load plugins and let them specify their own routes (but not for hubs).
        var pluginAssemblies = LoadPlugins(RouteTable.Routes);
        RouteTable.Routes.MapHubs();
        GlobalHost.DependencyResolver.Register(typeof(IAssemblyLocator), () => new PluginAssemblyLocator(pluginAssemblies));
    }
