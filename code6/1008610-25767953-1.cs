    public static IQueryable<T> CreateSourceQuery<T>(ICollection<T> collection)
         where T : class
    {
        if (collection == null) throw new ArgumentNullException("collection");
        var entityCollection = collection as System.Data.Entity.Core.Objects.DataClasses.EntityCollection<T>;
        if (entityCollection == null)
            return collection.AsQueryable();
        else
            return entityCollection.CreateSourceQuery();
    }
