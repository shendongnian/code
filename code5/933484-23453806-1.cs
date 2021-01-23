    public class Person
    {
        [JsonIgnore]
        publis string FullName {get; set;}
        [BsonIgnore]
        public string FirstName { get; set; }
        [BsonIgnore]
        public string LastName { get; set; }
    }
