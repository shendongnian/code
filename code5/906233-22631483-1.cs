    private void RegisterImageConverters(Container container)
    {
        var pluginAssemblies = this.LoadAssemblies(this.settings.PluginDirectory);
        var pluginTypes =
            from dll in pluginAssemblies
            from type in dll.GetExportedTypes()
            where typeof(IImageConverter).IsAssignableFrom(type)
            where !type.IsAbstract
            where !type.IsGenericTypeDefinition
            select type;
        container.RegisterAll<IImageConverter>(pluginTypes);
    }
    private IEnumerable<Assembly> LoadAssemblies(string folder)
    {
        IEnumerable<string> dlls =
            from file in new DirectoryInfo(folder).GetFiles()
            where file.Extension == ".dll"
            select file.FullName;
        IList<Assembly> assemblies = new List<Assembly>();
        foreach (string dll in dlls) {
            try {
                assemblies.Add(Assembly.LoadFile(dll));
            }
            catch { }
        }
        return assemblies;
    }
