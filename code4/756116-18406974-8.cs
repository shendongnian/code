    public class User
    {
        public User()
        {
            this.Journeys = new List<Journey>();
        }
        
        public int Id { get; set; }
        public virtual IList<Journey> Journeys { get; set; }
    }
    public class Journey
    {
        public Journey()
        {
            this.Users = new List<User>();
        }
        
        public int Id { get; set; }
        public virtual IList<User> Users { get; set; }
    }
