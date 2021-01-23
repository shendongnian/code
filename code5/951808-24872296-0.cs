    ConventionRegistry.Register(
        "dates as documents",
        new ConventionPack
        {
            new DelegateMemberMapConvention("dates as documents", memberMap =>
            {
                if (memberMap .MemberType == typeof(DateTime))
                {
                    memberMap .SetSerializationOptions(new DateTimeSerializationOptions(DateTimeKind.Utc, BsonType.Document));
                }
            }),
        },
        t => true);
