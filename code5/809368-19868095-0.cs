	IEnumerable<IPluginTypeConfiguration> handlers =
		ObjectFactory.Model.PluginTypes
                           .Where(x => x.PluginType.IsGenericType &&
			        				   x.PluginType.GetGenericTypeDefinition() == 
                                                           typeof (IHandle<>));
	var allInstances = new List<object>();
	
	foreach (IPluginTypeConfiguration pluginTypeConfiguration in handlers)
	{
		var instancesForPluginType = 
                  ObjectFactory.GetAllInstances(pluginTypeConfiguration.PluginType)
                               .OfType<object>();
		
		allInstances.AddRange(instancesForPluginType);
	}
