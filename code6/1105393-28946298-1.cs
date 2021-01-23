     public class Foo 
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int key { get; set; }
        public string value { get; set; }
        public bool isActive { get; set; }
    
        [BsonIgnoreIfNull]
        public DateTime? deletedAt { get; set; }
    }
    
    public class Parent
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public List<Foo> subdoc { get; set; } 
    }
