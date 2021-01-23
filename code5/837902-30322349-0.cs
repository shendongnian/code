    public class Account
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public string Address { get; set; }
        [JsonIgnore]
        public string City { get; set; }
        [JsonIgnore]
        public string State { get; set; }
    .
    .
    .
    }
