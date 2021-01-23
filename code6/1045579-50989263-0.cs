        public static class ModelBuilderExtenions
        {
            private static IEnumerable<Type> GetMappingTypes(this Assembly assembly, Type mappingInterface)
            {
                return assembly.GetTypes().Where(x => !x.IsAbstract && x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));
            }
    
            public static void AddEntityConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
            {
                // Types that do entity mapping
                var mappingTypes = assembly.GetMappingTypes(typeof(IEntityTypeConfiguration<>));
    
                // Get the generic Entity method of the ModelBuilder type
                var entityMethod = typeof(ModelBuilder).GetMethods()
                    .Single(x => x.Name == "Entity" &&
                            x.IsGenericMethod &&
                            x.ReturnType.Name == "EntityTypeBuilder`1");
    
                foreach (var mappingType in mappingTypes)
                {
                    // Get the type of entity to be mapped
                    var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();
    
                    // Get the method builder.Entity<TEntity>
                    var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArg);
    
                    // Invoke builder.Entity<TEntity> to get a builder for the entity to be mapped
                    var entityBuilder = genericEntityMethod.Invoke(modelBuilder, null);
    
                    // Create the mapping type and do the mapping
                    var mapper = Activator.CreateInstance(mappingType);
                    mapper.GetType().GetMethod("Configure").Invoke(mapper, new[] { entityBuilder });
                }
            }
    
    
        }
