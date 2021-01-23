    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public User(User copyFrom)
        {
            Id = copyFrom.Id;
            Name = copyFrom.Name;
            // copy all the fields you need
        }
    }
    public class Player : User
    {
        public TimeSpan TimeInGame { get; set; }
        public Player(User userInfo)
            : base(userInfo)
        {
        }
    }
