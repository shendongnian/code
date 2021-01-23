	public static void RegisterImplementationsClosingInterface(UnityContainer container, Assembly assembly, Type genericInterface)
	{
		foreach(var type in Assembly.GetExecutingAssembly().GetExportedTypes())
		{
			//	 concrete class or not?
			if(!type.IsAbstract && type.IsClass)
			{
				// has the interface or not?
				var iface = type.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition () 
                        == genericInterface).FirstOrDefault();
				if(iface != null)
				{
					container.RegisterType(iface, type);
				}
			}
												   
		}
	}
