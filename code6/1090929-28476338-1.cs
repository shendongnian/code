	foreach(Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
	{
		if (asm.GetName().Name.EndsWith("static"))
		{
			foreach(Type type in asm.GetTypes())
			{
				if (type.Name.EndsWith("cache"))
				{
					MethodInfo method = type.GetMethod("invalidate", BindingFlags.Static | BindingFlags.Public, null, Type.EmptyTypes, null);
					if (method != null)
						method.Invoke(null, null);
				}
			}
		}
	}
