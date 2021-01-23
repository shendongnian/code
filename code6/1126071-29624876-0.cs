    public override IMongoCollection<TDocument> GetCollection<TDocument>(string name, MongoCollectionSettings settings)
    {
        Ensure.IsNotNullOrEmpty(name, "name");
        settings = settings == null ?
            new MongoCollectionSettings() :
            settings.Clone();
        settings.ApplyDefaultValues(_settings);
        return new MongoCollectionImpl<TDocument>(this, new CollectionNamespace(_databaseNamespace, name), settings, _cluster, _operationExecutor);
    }
