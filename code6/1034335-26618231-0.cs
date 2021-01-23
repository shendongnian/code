    public abstract class BaseNamedEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class Group : BaseNamedEntity
    {
        public virtual ICollection<User> Users { get; set; }
    }
    public class User : BaseNamedEntity
    {
        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
