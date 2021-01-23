    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Friend> Friends { get; set; }
    }
    public class Friend
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
    }
