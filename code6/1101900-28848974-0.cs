    public abstract class BaseEntity : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("ObjectId")]
        public virtual ICollection<Note> Notes { get; set; }
    
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            Notes = new List<Note>();
        }
    }
    
    public class Note
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ObjectId { get; set; } //student, school, etc
        public string Name { get; set; }
        public string Value { get; set; }
    
        public Note()
        {
            Id = Guid.NewGuid();
        }
    }
