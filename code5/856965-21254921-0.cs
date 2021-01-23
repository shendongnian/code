    .Mappings(m =>
    {
        foreach (var assembly in MapAssemblies)
        {
            m.FluentMappings.AddFromAssembly(assembly);
            m.HbmMappings.AddFromAssembly(assembly);
            m.AutoMappings.Add(..)
        }    
    })
...
    .ExposeConfiguration(cfg => {
        foreach (var assembly in MapAssemblies)
        {
            cfg.AddDeserializedMapping(HbmMappingHelper.GetMappings(assembly), null);
            cfg.AddInputStream(NHibernate.Mapping.Attributes.HbmSerializer.Default.Serialize(
                        System.Reflection.Assembly.GetExecutingAssembly()));
        }
