    // There's other options for each parameter to RegisterTypes()
    // (and you can supply your own custom options)
    container.RegisterTypes(
        AllClasses.FromLoadedAssemblies().
            Where(type => typeof(IRunOnEachRequest).IsAssignableFrom(type)),
        WithMappings.FromAllInterfaces,
        WithName.TypeName,
        WithLifetime.Transient);
    foreach (var task in container.ResolveAll<IRunOnEachRequest>())
        task.Execute();
