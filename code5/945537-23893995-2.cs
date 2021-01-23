    private static DbEntityEntry GetRelatedEntityByKey(DbContext context, EntityKey relatedEntityKey)
    {
        ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
        object relatedEntity;
        if (objectContext.TryGetObjectByKey(relatedEntityKey, out relatedEntity))
        {
            return context.Entry(relatedEntity);
        }
        return null;
    }
