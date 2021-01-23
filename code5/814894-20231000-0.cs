    using System.Reflection;
    
    .....
    
    var migrationInterfaceType = typeof (Migration);
    var migrations =
        migrationInterfaceType.GetTypeInfo().Assembly.ExportedTypes
                              .Where(type => migrationInterfaceType.GetTypeInfo().IsSubclassOf(type) && !type.IsAbstract)
                              .OrderBy(type => type.Name);
