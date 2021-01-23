    public static void RemoveAll<T>(this MongoCollection<T> collection,
        Expression<Func<T, bool>> criteria, Func<T, BsonValue> idSelector)
    {
        foreach (T entity in collection.AsQueryable<T>().Where(criteria))
            collection.Remove(Query.EQ("_id", idSelector(entity)));
    }
