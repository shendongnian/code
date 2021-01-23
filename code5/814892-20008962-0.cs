    var migrations = typeof(IMigration).GetTypeInfo()
                                       .Assembly
                                       .DefinedTypes
                                       .Where(type => type.GetInterfaces()
                                                          .Any(itf=> 
                                             itf == typeof(IMigration)) && 
                                             !type.IsAbstract)
                                       .OrderBy(type => type.Name);
 
