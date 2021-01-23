    Assembly assembly = Assembly.LoadFrom("MyAssembly.dll");
    
    Container.Register(
        Classes.FromAssembly(assembly)
               .InNamespace("MyNamespace")
               .WithServiceAllInterfaces());
