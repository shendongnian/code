    return AutoMap
            .Assembly(System.Reflection.Assembly.GetCallingAssembly())
            .Where(t => t.Namespace == "Escape.Data.Entities")
            // use the convention
            .Conventions.AddFromAssemblyOf<MyIdColumnNameConvention >()
