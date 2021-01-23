    public class HbmMappingHelper
    {
        public static HbmMapping GetMappings(Type[] types)
        {
            ModelMapper mapper = new ModelMapper();
            foreach (var type in types)
            {
                mapper.AddMappings(Assembly.GetAssembly(type).GetExportedTypes());
            }
            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
        public static HbmMapping GetMappings(Assembly assembly)
        {
            ModelMapper mapper = new ModelMapper();
            mapper.AddMappings(assembly.GetExportedTypes());
            
            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
