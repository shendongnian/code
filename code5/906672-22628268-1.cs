    public enum PersonType { Teacher, Student }; 
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Group Group { get; set; }
        public PersonType PropPersonType { get; set; }
    }
