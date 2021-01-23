    public class User
    {
        public int Id { get; set; }
        public IList<Journey> Journeys { get; set; }
    }
    public class Journey
    {
        public int Id { get; set; }
        public IList<User> Users { get; set; }
    }
