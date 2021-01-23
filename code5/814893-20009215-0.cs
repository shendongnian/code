    var currentAssembly = GetType().GetTypeInfo().Assembly;
    var migrations = currentAssembly.DefinedTypes
                                    .Where( type => type.ImplementedInterfaces
                                                        .Any(inter => inter == typeof (IMigration)) && !type.IsAbstract )
                                    .OrderBy( type => type.Name );
