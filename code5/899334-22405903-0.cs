    private Type FindRepositoryType (Type entityType)
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.BaseType != null
                && t.BaseType.IsGenericType
                && t.BaseType.GetGenericTypeDefinition() == typeof(BaseRepository<>)
                && t.BaseType.GetGenericArguments()[0] == entityType)
            .FirstOrDefault();
    }
