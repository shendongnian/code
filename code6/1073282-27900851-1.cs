    public EntityType FindEntityType(DbModel model, Type type)
    {
        var const metadataPropertyName = "http://schemas.microsoft.com/ado/2013/11/edm/customannotation:ClrType";
        var entityType = model.ConceptualModel.EntityTypes.SingleOrDefault(
            e => e.MetadataProperties.Contains(metadataPropertyName) &&
                 e.MetadataProperties.GetValue(metadataPropertyName).Value as Type == type
            );
        return entityType;
    }
