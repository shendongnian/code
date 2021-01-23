    public enum PersonType
    {
        Customer = 0,
        Employee = 1,
        Supplier = 2
    }
    public class RootObject
    {
        Person[] _persons = new Person[] {
            new Customer(),
            new Employee(),
            new Supplier()
        };
        public Person[] Persons { get { return _persons; } }
    }
