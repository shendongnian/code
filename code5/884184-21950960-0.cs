    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Address Address { get; set; }
    }
    public class Address
    {
        public int Id { get; set; }
        public string State { get; set; }
    }
