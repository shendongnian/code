    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public User(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    public class Player : User
    {
        public TimeSpan TimeInGame { get; set; }
        public Player(User userInfo)
            : base(userInfo.Id, userInfo.Name)
        {
        }
    }
