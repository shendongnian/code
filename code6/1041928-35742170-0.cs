       var assemblyType = typeof(MyCustomAssemblyType).GetTypeInfo();
       builder.RegisterAssemblyTypes(assemblyType.Assembly)
       .Where(t => t.Name.EndsWith("Repository"))
       .AsImplementedInterfaces()
       .InstancePerRequest();
