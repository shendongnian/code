    public class Person
    {
        public string FirstName { get; set; }
    
        public string LastName { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public bool IsEmployed { get; set; }
    }
