    public class Entity
    {
        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }
    
        [BsonElement("id")]
        public int Id { get; set; }
        [BsonElement("Time")]
        public DateTime Time{ get; set; }
        [BsonElement("Round")]
        public string Round{ get; set; }
        [BsonElement("Force")]
        public double? Force{ get; set; }
        [BsonElement("FightID")]
        public string FightID{ get; set; }
    }
