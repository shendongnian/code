    public void Bootstrap()
    {
        var applicationContext = new ApplicationContext();
        IModule[] modules = LoadModulesFromDirectoryAssemblies();
        foreach (var module in modules)
        {
            module.Initialize(applicationContext);
        }
    }
