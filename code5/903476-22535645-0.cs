    public class AutomapperTypeAdapterFactory
            :ITypeAdapterFactory
        {
            public AutomapperTypeAdapterFactory()
            {
                //scan all assemblies finding Automapper Profile
                var profiles = AppDomain.CurrentDomain
                                        .GetAssemblies()
                                        .SelectMany(a => a.GetTypes())
                                        .Where(t => t.BaseType == typeof(Profile));
    
                Mapper.Initialize(cfg =>
                {
                    foreach (var item in profiles)
                    {
                        if (item.FullName != "AutoMapper.SelfProfiler`2")
                            cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                    } 
                });
                //===>>
                MapperRegistry.Mappers.Remove(MapperRegistry.Mappers.FirstOrDefault(x => x is DataReaderMapper));
            }
       }
