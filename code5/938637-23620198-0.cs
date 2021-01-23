    var assembly = Assembly.Load("Assembly.Name.Here");
    foreach (var type in assembly.GetTypes().Where(x => typeof (IInterfaceEachClassImplements).IsAssignableFrom(x))) {
        RuntimeTypeModel
            .Default
            .Add(type, false)
            .Add(type.GetProperties()
                .Select(x => x.Name)
                .ToArray());
    }
