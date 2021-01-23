    public class Obj
    {
        public string Id { get; set; }
    
        [JsonProperty("User")]
        public string UserName { get; set; }
    
        public Userinfo Userinfo { get; set; }
    }
    
    public class Userinfo
    {
        public string Id { get; set; }
        public string Online { get; set; }
    }
