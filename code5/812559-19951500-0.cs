    public class Person 
    {
        public Person(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
    public class Team
    {
        public Person Manager { get; set; }
        public Person Trainer { get; set; }
    }
