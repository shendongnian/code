    public class Entity : IEntity
    {
        public string Name { get; set; }
    }
    public class User : Entity
    {
        public string Password { get; set; }
    }
