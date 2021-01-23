    var obj = JsonConvert.DeserializeObject<RootObject>(json)
----
    public class User
    {
        public string type { get; set; }
        public string avatar_url { get; set; }
        public string email_address { get; set; }
        public bool admin { get; set; }
        public string name { get; set; }
        public string created_at { get; set; }
        public int id { get; set; }
    }
    public class Room
    {
        public string topic { get; set; }
        public int membership_limit { get; set; }
        public bool locked { get; set; }
        public string name { get; set; }
        public List<User> users { get; set; }
        public bool full { get; set; }
        public bool open_to_guests { get; set; }
        public string updated_at { get; set; }
        public string created_at { get; set; }
        public int id { get; set; }
    }
    public class RootObject
    {
        public Room room { get; set; }
    }
