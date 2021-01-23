    public class College
    {
        public  College 
        {
            Id = ObjectId.GenerateNewId();        
        }
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
