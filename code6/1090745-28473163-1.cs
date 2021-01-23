	List<IPlugin> _LISTOFALLPLUGINS = new List<IPlugin>(); 
	public void LoadPlugins()
	{
		if (Directory.Exists(YOURFOLDERPATH_HERE)) 
		{
			string[] pluginfiles = Directory.GetFiles(YOURFOLDERPATH_HERE, "*.dll", SearchOption.AllDirectories); 
			var pluginbasetype = typeof(IPlugin);
			foreach (string pluginpath in pluginfiles)
			{
				Assembly assembly = Assembly.LoadFile(pluginpath);
				List<Type> plugins = assembly.GetTypes().Where(t => pluginbasetype.IsAssignableFrom(t)).ToList();
				foreach (Type plugintype in plugins)
				{
					if (!plugintype.IsAbstract)
					{
						IRzConfiguratorPlugin plugin = assembly.CreateInstance(plugintype.FullName) as IPlugin;
						_LISTOFALLPLUGINS.Add(plugin);
					}
				}
			}
		}
	}
