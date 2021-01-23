    public class MongoObject
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]    // <--- this is what was missing
        public string MongoID { get; set; }
    
        public int Index { get; set; }
    }
