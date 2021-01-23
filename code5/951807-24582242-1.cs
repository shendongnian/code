    ConventionRegistry.Register(
                "Dates as utc documents",
                new ConventionPack
                {
                    new MemberSerializationOptionsConvention(typeof(DateTime), new DateTimeSerializationOptions(DateTimeKind.Utc, BsonType.Document)),
                },
                t => true);
