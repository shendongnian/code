    [Table("Persons")]
    public abstract class Person
    {
        [Key]
        public int Id { get; set; }
        //...
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
    [Table("Groups")]
    public class Group
    {
        [Key]
        public int Id { get; set; }
        //...
        public virtual ICollection<Person> Persons { get; set; }    
    }
