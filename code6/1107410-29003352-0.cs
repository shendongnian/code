    var map = AutoMap.AssemblyOf<AutomappingConfiguration>(new AutomappingConfiguration())
        .Conventions.AddFromAssemblyOf<AutomappingConfiguration>()
        .UseOverridesFromAssemblyOf<AutomappingConfiguration>();
    foreach (var c in map.Conventions.Find<TableConvention>())
    {
        c.AllWritable = allWritable;
    }
