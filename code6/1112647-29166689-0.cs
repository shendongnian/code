    public class Person
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Value {get; set;}
        public PersonAttributes attributes {get; set;}
        public List<Person> Children {get; set;}
    }
    public class PersonAttributes
    {
        public bool HasChild {get; set;}
        public bool HasParent {get; set;}
        public int ParentId {get; set;}
    }
