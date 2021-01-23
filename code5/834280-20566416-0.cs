    public class UserModel
    {
        public int Id { get; set; }
    
        public string Username { get; set; }
    
        public string FirstName { get; set; }
    
        public string LastName { get; set; }
    
        public string Email { get; set; }
    
        public string Password { get; set; }
    
        public string GravatarHash { get; set; }
    
        public string Country { get; set; }
    
        public int OrganizationId { get; set; }
    
        public bool IsLocked { get; set; }
    
        public DateTime CreatedDate { get; set; }
    
        public DateTime UpdatedDate { get; set; }
    
        public bool DataLoaded { get; set; }
    }
    var input =
        "{\"Id\":5,\"Username\":\"Sid\",\"FirstName\":\"Sid \",\"LastName\":\"LastSid\",\"Email\":\"test@gmail.com\",\"Password\":\"sample\",\"GravatarHash\":\"http://www.gravatar.com/avatar/f4f901415af5aff35801e8444cd5adc1?d=retro&?s=50\",\"Country\":\"Moon\",\"OrganizationId\":1,\"IsLocked\":false,\"CreatedDate\":\"12/13/2013 2:34:28 AM\",\"UpdatedDate\":\"12/13/2013 2:34:28 AM\",\"DataLoaded\":true}";
    
    var userModel = JsonConvert.DeserializeObject<UserModel>(input);
