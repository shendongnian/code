        .Mappings(m => m.AutoMappings.Add(
               AutoMap.AssemblyOf<CupTree>(config)
               .Conventions.Add(
                  DefaultLazy.Never(),
                  Table.Is(x => x.EntityType.Name + "s"))
               .UseOverridesFromAssembly(Assembly.GetAssembly(typeof(CupTreeOverride)))
               ).ExportTo(@"C:\nh.out"))
