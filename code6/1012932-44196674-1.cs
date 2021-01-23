        private static readonly IEnumerable<Type> KnownMessageTypes = KnownPayloadTypes
            .Select(t => typeof(Message<>).MakeGenericType(t));
          KnownPayloadTypes
                .Concat(KnownMessageTypes)
                .ConcatOne(typeof(object))
                .ConcatOne(typeof(Message))
                .ForEach(t =>
                {
                    var bsonClassMap = new BsonClassMap(t);
                    bsonClassMap.AutoMap();
                    bsonClassMap.SetDiscriminator(t.FullName);
                    BsonClassMap.RegisterClassMap(bsonClassMap);
                }
                );
