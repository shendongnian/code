    public class Person
    {
        public Person()
    	{
            this.Address = new Address();
    	}
        public string FirstName {get; set;}
        public Address {get; set;}
    }
.
    // Don´t need to do Person p = new Person(){ FirstName="Test", Address = new Address()}; 
    Person p = new Person();
