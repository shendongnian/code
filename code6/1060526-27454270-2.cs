    static void Main(string[] args)
    {
        PluginContainer<IStandAlone> container = new PluginContainer<IStandAlone>();
        var plugins = container.GetPlugins();
        foreach (var plugin in plugins)
        {
            plugin.Run();
        }
        Console.ReadLine();
    }
