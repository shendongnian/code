    public abstract class NamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Person : NamedEntity
    {
        public Person()
        {
            Office = new Office();
        }
        public Office Office { get; set; }
    }
    public class Office : NamedEntity
    {
        public Office()
        {
            Address = new Address();
            ParentOrganisation = new Organisation();
        }
        public Address Address { get; set; }
        public Organisation ParentOrganisation { get; set; }
    }
    public class Address
    {
        public string AddressLine1 { get; set; }
    }
    public class Organisation : NamedEntity
    {
    }
