    public class User
    {
        public string GivenName { get; set; }
    
        public string FamilyName { get; set; }
    
        public List<Photo> Photos { get; private set; }
    
        public User()
        {
            this.Photos = new List<Photo>();
        }
    }
