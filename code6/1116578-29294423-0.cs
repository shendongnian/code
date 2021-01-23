    public void Update(ObjectId id, Action<TEntity> updates)
    {
        var query = Query.EQ("_id", new BsonObjectId(id));
        var update = Update<TEntity>.Set(updates);
        var collection = GetCollection();
        collection.Update(query, update);
    }
