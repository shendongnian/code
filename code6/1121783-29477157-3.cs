    public class User
    {
    
    [BsonElement("Id")]
    public int Id { get; set; }
    [BsonElement("Email")]
    public string Email { get; set; }
    [BsonElement("Name")]
    public string Name{ get; set; }
    [BsonElement("Company")]
    public string Company { get; set; }
    [BsonElement("Array friends")]
    public List<Friend> Friends { get;set;}
    }
