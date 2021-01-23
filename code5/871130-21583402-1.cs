    Assembly asm = Assembly.GetExecutingAssembly();
    asm.GetTypes()
        .Where(type=> typeof(Controller).IsAssignableFrom(type)) //filter controllers
        .SelectMany(type => type.GetMethods())
        .Where(method => method.IsPublic && ! method.IsDefined(typeof(NonActionAttribute)));
