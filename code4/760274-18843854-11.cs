    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        MethodInfo addMethod = typeof(ConfigurationRegistrar).GetMethods().Single(m => m.Name == "Add" && m.GetGenericArguments().Any(a => a.Name == "TEntityType"));
        IList<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.GetName().Name.StartsWith("System") && !a.GetName().Name.StartsWith("Microsoft")).ToList();
        foreach (Assembly assembly in assemblies)
        {
            IList<Type> types = assembly.GetTypes().Where(t => t.BaseType != null && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)).ToList();
            foreach (Type type in types)
            {
                Type entityType = type.BaseType.GetGenericArguments().Single();
                object entityConfig = assembly.CreateInstance(type.FullName);
                addMethod.MakeGenericMethod(entityType).Invoke(modelBuilder.Configurations, new object[] { entityConfig });
            }
        }
    }
