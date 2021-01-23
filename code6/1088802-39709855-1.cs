    public static string GetColumnName(Type type, string propertyName, DbContext context)
    {
    var metadata = ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;
    // Get the part of the model that contains info about the actual CLR types
    var objectItemCollection = ((ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace));
    // Get the entity type from the model that maps to the CLR type
    var entityType = metadata
            .GetItems<EntityType>(DataSpace.OSpace)
            .Single(e => objectItemCollection.GetClrType(e) == type);
    // Get the entity set that uses this entity type
    var entitySet = metadata
        .GetItems<EntityContainer>(DataSpace.CSpace)
        .Single()
        .EntitySets
        .Single(s => s.ElementType.Name == entityType.Name);
    // Find the mapping between conceptual and storage model for this entity set
    var mapping = metadata.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
            .Single()
            .EntitySetMappings
            .Single(s => s.EntitySet == entitySet);
    // Find the storage entity set (table) that the entity is mapped
    var tableEntitySet = mapping
        .EntityTypeMappings.Single()
        .Fragments.Single()
        .StoreEntitySet;
    // Return the table name from the storage entity set
    var tableName = tableEntitySet.MetadataProperties["Table"].Value ?? tableEntitySet.Name;
    // Find the storage property (column) that the property is mapped
    var columnName = mapping
        .EntityTypeMappings.Single()
        .Fragments.Single()
        .PropertyMappings
        .OfType<ScalarPropertyMapping>()
        .Single(m => m.Property.Name == propertyName)
        .Column
        .Name;
    return tableName + "." + columnName;
    }
