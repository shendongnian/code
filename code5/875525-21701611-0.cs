	var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");
	var builder = args.ModelBuilder;
	foreach (Type x in assembly.GetTypes())
	{
		foreach (Type z in x.GetInterfaces())
		{
			Type y = x.BaseType;
			if ((y != null && y.IsGenericType && typeof(IOverride<>).IsAssignableFrom(y.GetGenericTypeDefinition())) || 
				(z.IsGenericType && typeof(IOverride<>).IsAssignableFrom(z.GetGenericTypeDefinition())))
			{
				// first difference - we get Configure method from real object, and not from IOverride
				var method = x.GetMethod("Configure");
				var target = z.GetGenericArguments().Single();
				var invoked = entityMethod.MakeGenericMethod(target).Invoke(builder, new object[] { });
				var func = method.MakeGenericMethod(typeof(string));
				// this one block can go to ModelCreating event as in your example,
				// but locally i didn't use it
				// second difference - we create instance of original type
				var obj = Activator.CreateInstance(x);
				// third one difference - we pass instance as `this` and pass invoked as parameter
				func.Invoke(obj, new[] { invoked });
			}
		}
	}
