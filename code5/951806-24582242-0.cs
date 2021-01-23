    ConventionRegistry.Register("dates as documents",
                            new ConventionPack{
                                    new DateTimeSerializationOptions(DateTimeKind.Utc, BsonType.Document)
                            },
                            t => true);
