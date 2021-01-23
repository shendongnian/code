    return AutoMap
            .Assembly(System.Reflection.Assembly.GetCallingAssembly())
            .Where(t => t.Namespace == "Escape.Data.Entities")
            // use the convention
            .Conventions.Add(PrimaryKey.Name.Is(x => x.EntityType.Name + "Id"))
            .Conventions.AddFromAssemblyOf<MyIdColumnNameConvention >()
