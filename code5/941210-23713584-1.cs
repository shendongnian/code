    public class Person
    {
        ...
        public virtual Name Name { get; set; }
    
    public class Name
    {
        public virtual Person NamedPerson { get; set; }
        public virtual string Initial { get; set; }    
        ...
