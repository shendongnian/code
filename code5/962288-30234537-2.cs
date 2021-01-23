    public class RegistrationAttempt
    {
        public string AttemptId { get; set; }
    }
    BsonClassMap.RegisterClassMap<RegistrationAttempt>(cm =>
    {
        cm.AutoMap();
        cm.MapIdProperty(c => c.AttemptId)
            .SetIdGenerator(StringObjectIdGenerator.Instance)
            .SetSerializer(new StringSerializer(BsonType.ObjectId));
    });
