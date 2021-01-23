    public abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class Customer : Person
    {
        public Address DeliveryAddress { get; set; }
    }
    public class Employee : Person
    {
        public string Profession { get; set; }
    }
