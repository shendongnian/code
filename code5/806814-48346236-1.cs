    BsonSerializer.RegisterSerializer(typeof(Dictionary<string, object>),
        new DictionaryInterfaceImplementerSerializer<Dictionary<string, object>, string, object>(
            DictionaryRepresentation.Document,
            new StringSerializer(),
            new DynamicValueSerializer()));
