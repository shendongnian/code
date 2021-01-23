    public static string GenerateIdFor<T>(this IAdvancedDocumentSessionOperations session)
    {
        // An entity instance is required to generate a key, but we only have a type.
        // We might not have a public constructor, so we must use reflection.
        var entity = Activator.CreateInstance(typeof(T), true);
        // Generate an ID using the commands and conventions from the current session
        var conventions = session.DocumentStore.Conventions;
        var databaseName = session.GetDatabaseName();
        var databaseCommands = session.GetDatabaseCommands();
        return conventions.GenerateDocumentKey(databaseName, databaseCommands, entity);
    }
