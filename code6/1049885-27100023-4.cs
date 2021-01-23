    public class User
    {   
        [BsonId]
        public ObjectId Id { get; set; }
 
        public string username { get; set; }
 
        public string status { get; set; }
 
        public List<Profile> profile { get; set; }
    }
    public class Profile
    {
 
        public string name { get; set; }
 
        public string age { get; set; }
 
        public string gender { get; set; }
    }
