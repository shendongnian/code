    AppSession.Current.ModulesConfiguration.Select(
                        module =>
                        {
                            var path = Path.Combine(Path.Combine(pathToAssemblies, module.ModuleRelativePathForDll),
                                module.BusinessModuleDllName);
                            return path;
                        })
                        .Select(Assembly.LoadFrom)
                        .SelectMany(a => a.GetTypes())
                        .FirstOrDefault(type => type.GetInterface(interfaceType.Name) != null);
