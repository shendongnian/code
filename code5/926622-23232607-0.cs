    public class DTO : IClientDTO {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public string SSN { get; set; }
    }
