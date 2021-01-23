    BsonClassMap.RegisterClassMap<GenericIdentity>(cm =>
    {
        cm.MapProperty(c => c.Name);
        cm.MapProperty(c => c.AuthenticationType);
        cm.MapCreator(i => new GenericIdentity(i.Name, i.AuthenticationType));
    });
