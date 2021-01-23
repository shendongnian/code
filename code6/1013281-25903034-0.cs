    public class Person
    {
        public string Name { get; set; }
        public AddressInfo Address { get; set; }
        public List<Person> Friends { get; set; }
        public Person()
        {
            //Avoid object reference not set exception.
            Friends = new List<Person>();
        }
    }
