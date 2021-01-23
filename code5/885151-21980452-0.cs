    public class Person {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    var bob = new Person { Name = "Bob", Age = 24 };
    var sally = new Person { Name = "Bob", Age = 23 };
    
    var people = new List<Person>() { bob, sally };
