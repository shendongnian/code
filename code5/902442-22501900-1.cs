    public TContent Create<TContent>(string name, ...)
    {
        ...
        // SP executes a few insers and returns newly created data instance
        return db.Single<TContent>(
            new Sql.Builder.Append(";exec dbo.CreateContent @Type, @Name, ...", new {
                Type = RegisteredTypes[typeof TContent],
                Name = name,
                ...
            }));
    }
