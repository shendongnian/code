    public interface IParent
    {
        ICollection<Person> Children { get; set; }
    }
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? MotherId { get; set; }
        public Female Mother { get; set; }
        public int? FatherId { get; set; }
        public Male Father { get; set; }
    }
    public class Male : Person, IParent
    {
        public virtual ICollection<Person> Children { get; set; }
    }
    public class Female : Person, IParent
    {
        public virtual ICollection<Person> Children { get; set; }
    }
