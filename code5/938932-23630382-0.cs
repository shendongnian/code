    var appServiceClassTypes = AppDomain.CurrentDomain.GetAssemblies()
                                        .SelectMany(x => x.GetTypes())
                                        .Where(x => x.IsClass && x.Namespace == ...)
                                        .ToList();
    var appServiceClasses = appServiceClassTypes.Select(x => x.Name);
    var methodNames = appServiceClassTypes.SelectMany(x => x.GetMethods())
                                          .Select(x => x.Name)
                                          .ToList();
